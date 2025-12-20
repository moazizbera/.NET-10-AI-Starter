using DotNet10Ai.ConsoleApp.Models;

namespace DotNet10Ai.ConsoleApp.Memory;

public sealed class ConversationMemory
{
    private readonly List<ChatMessage> _messages = new();

    public IReadOnlyList<ChatMessage> Messages => _messages;

    public ConversationMemory()
    {
        _messages.Add(CreateSystemMessage());
    }

    private static ChatMessage CreateSystemMessage() => new ChatMessage
    {
        Role = "system",
        Content = "You are a .NET AI assistant. Be concise and give practical C#/.NET guidance."
    };

    public void AddUser(string text)
    {
        _messages.Add(new ChatMessage
        {
            Role = "user",
            Content = text
        });
    }

    public void AddAssistant(string text)
    {
        _messages.Add(new ChatMessage
        {
            Role = "assistant",
            Content = text
        });
    }

    public void Reset()
    {
        _messages.Clear();
        _messages.Add(CreateSystemMessage());
    }
}
