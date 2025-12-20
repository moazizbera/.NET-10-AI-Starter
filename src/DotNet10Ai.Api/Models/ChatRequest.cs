namespace DotNet10Ai.Api.Models;

public sealed class ChatRequest
{
    public string Message { get; set; } = string.Empty;

    // Optional, default session
    public string? SessionId { get; set; }
}
