using DotNet10Ai.Api.Models;

namespace DotNet10Ai.Api.Ai;

public interface IAiInferenceService
{
    string ProviderName { get; }

    // Episode 4: now works on full conversation history
    Task<string> ChatAsync(IReadOnlyList<ChatMessage> messages, CancellationToken ct);
}
