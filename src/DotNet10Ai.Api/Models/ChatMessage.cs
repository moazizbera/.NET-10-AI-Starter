namespace DotNet10Ai.Api.Models;

public enum ChatRole
{
    System,
    User,
    Assistant
}

public sealed class ChatMessage
{
    public ChatRole Role { get; }
    public string Content { get; }

    public ChatMessage(ChatRole role, string content)
    {
        Role = role;
        Content = content;
    }
}
