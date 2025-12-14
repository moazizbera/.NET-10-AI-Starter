namespace DotNet10Ai.Api.Options;

public sealed class AiOptions
{
    public string Provider { get; set; } = "Local";
    public LocalAiOptions Local { get; set; } = new();
    public CloudAiOptions Cloud { get; set; } = new();
}

public sealed class LocalAiOptions
{
    public string OllamaUrl { get; set; } = "http://localhost:11434";
    public string Model { get; set; } = "phi3";
}

public sealed class CloudAiOptions
{
    public string Provider { get; set; } = "OpenAI";
    public string Model { get; set; } = "gpt-4o-mini";
}
