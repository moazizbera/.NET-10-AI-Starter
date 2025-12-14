namespace DotNet10Ai.Api.Ai;

public interface IAiInferenceService
{
    string ProviderName { get; }
    Task<string> ChatAsync(string message, CancellationToken ct);
}
