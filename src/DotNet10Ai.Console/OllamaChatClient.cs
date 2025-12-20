using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using DotNet10Ai.ConsoleApp.Models;

namespace DotNet10Ai.ConsoleApp;

public sealed class OllamaChatClient
{
    private readonly HttpClient _http;

    public OllamaChatClient(string baseUrl)
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = Timeout.InfiniteTimeSpan
        };
    }

    public async Task<string> StreamChatAsync(
        IEnumerable<ChatMessage> messages,
        CancellationToken ct = default)
    {
        var payload = new
        {
            model = "phi3",
            messages = messages.Select(m => new
            {
                role = m.Role,
                content = m.Content
            }),
            stream = true
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "/api/chat")
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
                var chunk = msg.GetProperty("content").GetString();
                if (!string.IsNullOrEmpty(chunk))
                {
                    sb.Append(chunk);
                    System.Console.Write(chunk);
                }
            }
        }

        System.Console.WriteLine();
        return sb.ToString();
    }
}
