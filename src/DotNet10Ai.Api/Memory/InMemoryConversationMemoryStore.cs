using System.Collections.Concurrent;
using DotNet10Ai.Api.Models;

namespace DotNet10Ai.Api.Memory;

public interface IConversationMemoryStore
{
    IReadOnlyList<ChatMessage> GetHistory(string sessionId);
    void AppendUserMessage(string sessionId, string content);
    void AppendAssistantMessage(string sessionId, string content);
    void Reset(string sessionId);
}

public sealed class InMemoryConversationMemoryStore : IConversationMemoryStore
{
    private const int MaxMessagesPerSession = 40;

    private readonly ConcurrentDictionary<string, List<ChatMessage>> _sessions = new();

    private static readonly ChatMessage DefaultSystemPrompt =
        new(ChatRole.System,
            "You are a senior .NET AI assistant. " +
            "You help with C#, .NET, architecture, cloud, and AI integration. " +
            "Be concise, practical, and give code when helpful.");

    public IReadOnlyList<ChatMessage> GetHistory(string sessionId)
    {
        var list = GetOrCreateSession(sessionId);
        return list.ToList(); // return a copy
    }

    public void AppendUserMessage(string sessionId, string content)
    {
        var list = GetOrCreateSession(sessionId);
        list.Add(new ChatMessage(ChatRole.User, content));
        TrimIfNeeded(list);
    }

    public void AppendAssistantMessage(string sessionId, string content)
    {
        var list = GetOrCreateSession(sessionId);
        list.Add(new ChatMessage(ChatRole.Assistant, content));
        TrimIfNeeded(list);
    }

    public void Reset(string sessionId)
    {
        _sessions.TryRemove(sessionId, out _);
    }

    private List<ChatMessage> GetOrCreateSession(string sessionId)
    {
        return _sessions.GetOrAdd(sessionId, _ =>
        {
            var list = new List<ChatMessage> { DefaultSystemPrompt };
            return list;
        });
    }

    private static void TrimIfNeeded(List<ChatMessage> list)
    {
        // Always keep the system message at index 0
        while (list.Count > MaxMessagesPerSession)
        {
            // remove oldest non-system message
            if (list.Count <= 1) break;
            list.RemoveAt(1);
        }
    }
}
