using DotNet10Ai.Api.Options;
using Microsoft.Extensions.Options;

namespace DotNet10Ai.Api.Ai;

public sealed class AiServiceRouter : IAiInferenceService
{
    private readonly IAiInferenceService _local;
    private readonly IAiInferenceService _cloud;
    private readonly IOptionsMonitor<AiOptions> _options;

    public AiServiceRouter(
        IAiInferenceService local,
        IAiInferenceService cloud,
        IOptionsMonitor<AiOptions> options)
    {
        _local = local;
        _cloud = cloud;
        _options = options;
    }

    public string ProviderName => Selected().ProviderName;

    public Task<string> ChatAsync(string message, CancellationToken ct)
        => Selected().ChatAsync(message, ct);

    private IAiInferenceService Selected()
    {
        var provider = _options.CurrentValue.Provider?.Trim() ?? "Local";
        return provider.Equals("Cloud", StringComparison.OrdinalIgnoreCase) ? _cloud : _local;
    }
}
