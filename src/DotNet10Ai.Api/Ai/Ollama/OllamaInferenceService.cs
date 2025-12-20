using System.Net.Http.Json;
using DotNet10Ai.Api.Models;
using DotNet10Ai.Api.Options;
using Microsoft.Extensions.Options;

namespace DotNet10Ai.Api.Ai.Ollama;

public sealed class OllamaInferenceService : IAiInferenceService
{
    private readonly HttpClient _http;
    private readonly IOptionsMonitor<AiOptions> _options;

    public OllamaInferenceService(HttpClient http, IOptionsMonitor<AiOptions> options)
    {
        _http = http;
        _options = options;
    }

    public string ProviderName => "Local(Ollama)";

    public async Task<string> ChatAsync(IReadOnlyList<ChatMessage> messages, CancellationToken ct)
    {
        var local = _options.CurrentValue.Local;

        var payload = new
        {
            model = local.Model,
            messages = messages.Select(m => new
            {
                role = m.Role switch
                {
                    ChatRole.System => "system",
                    ChatRole.User => "user",
                    ChatRole.Assistant => "assistant",
                    _ => "user"
                },
                content = m.Content
            }).ToArray(),
            stream = false
        };

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            local.OllamaUrl + "/api/chat")
        {
            Content = JsonContent.Create(payload)
        };

        using var response = await _http.SendAsync(request, ct);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadFromJsonAsync<OllamaChatResponse>(
            cancellationToken: ct);

        return body?.message?.content?.Trim() ?? string.Empty;
    }

    private sealed class OllamaChatResponse
    {
        public OllamaMessage? message { get; set; }
    }

    private sealed class OllamaMessage
    {
        public string? role { get; set; }
        public string? content { get; set; }
    }
}
