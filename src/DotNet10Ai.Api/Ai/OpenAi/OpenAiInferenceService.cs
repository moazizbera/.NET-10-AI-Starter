using DotNet10Ai.Api.Options;
using Microsoft.Extensions.Options;
using OpenAI.Chat;
using System.ClientModel;

namespace DotNet10Ai.Api.Ai.OpenAi;

public sealed class OpenAiInferenceService : IAiInferenceService
{
    private readonly ChatClient _chatClient;

    public OpenAiInferenceService(IOptionsMonitor<AiOptions> options)
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("OPENAI_API_KEY is not set. Set it to use Cloud provider.");

        var model = options.CurrentValue.Cloud.Model;
        _chatClient = new ChatClient(model, apiKey);
    }

    public string ProviderName => "Cloud(OpenAI)";

    public async Task<string> ChatAsync(string message, CancellationToken ct)
    {
        var messages = new List<ChatMessage>
    {
        new SystemChatMessage("You are a helpful assistant. Reply concisely."),
        new UserChatMessage(message)
    };

        ClientResult<ChatCompletion> result =
            await _chatClient.CompleteChatAsync(messages, cancellationToken: ct);

        ChatCompletion completion = result.Value;

        return completion.Content[0].Text.Trim();
    }

}
