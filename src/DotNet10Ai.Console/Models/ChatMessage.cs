namespace DotNet10Ai.ConsoleApp.Models;

public class ChatMessage
{
    public string Role { get; set; } = string.Empty;   // "system", "user", "assistant"
    public string Content { get; set; } = string.Empty;
}
