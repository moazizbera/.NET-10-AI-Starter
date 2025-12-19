using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
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

    public async Task<string> ChatAsync(string message, CancellationToken ct)
    {
        var local = _options.CurrentValue.Local;

        var payload = new
        {
            model = local.Model,
            messages = new[]
            {
                new { role = "user", content = message }
            },
            stream = true
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, local.OllamaUrl+"/api/chat")
        {
            Content = JsonContent.Create(payload)
        };

        using var response = await _http.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            ct);

        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync(ct);
        using var reader = new StreamReader(stream);

        var sb = new StringBuilder();

        while (true)
        {
            var line = await reader.ReadLineAsync();
            if (line == null) break;
            if (string.IsNullOrWhiteSpace(line)) continue;

            var json = JsonDocument.Parse(line);

            if (json.RootElement.TryGetProperty("message", out var msg))
            {
                var content = msg.GetProperty("content").GetString();
                sb.Append(content);
            }
        }

        return sb.ToString();
    }
}
