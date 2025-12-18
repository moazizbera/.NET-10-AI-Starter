using DotNet10Ai.ConsoleApp.Models;

namespace DotNet10Ai.ConsoleApp;
//Test
public sealed class ChatSession
{
    private readonly List<ChatMessage> _messages = new();

    public IReadOnlyList<ChatMessage> Messages => _messages;

    public void AddSystem(string text)
        => _messages.Add(new ChatMessage("system", text));

    public void AddUser(string text)
        => _messages.Add(new ChatMessage("user", text));

    public void AddAssistant(string text)
        => _messages.Add(new ChatMessage("assistant", text));

    public void Clear()
    {
        _messages.Clear();
        AddSystem(DefaultSystemPrompt);
    }

    public const string DefaultSystemPrompt =
        "You are a senior software architect and AI engineer. " +
        "Answer clearly, concisely, and factually. " +
        "Do not invent technologies or acronyms. " +
        "Python is mainly used for model training and research; " +
        ".NET is commonly used for AI integration and production systems.";
}
