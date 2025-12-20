using DotNet10Ai.Api.Ai;
using DotNet10Ai.Api.Memory;
using DotNet10Ai.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet10Ai.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IAiInferenceService _ai;
    private readonly IConversationMemoryStore _memory;

    public ChatController(IAiInferenceService ai, IConversationMemoryStore memory)
    {
        _ai = ai;
        _memory = memory;
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponse>> Chat([FromBody] ChatRequest request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest("Message is required.");
        }

        var sessionId = string.IsNullOrWhiteSpace(request.SessionId)
            ? "default"
            : request.SessionId.Trim();

        // 1) Add user message to memory
        _memory.AppendUserMessage(sessionId, request.Message);

        // 2) Get full history (system + all turns)
        var history = _memory.GetHistory(sessionId);

        // 3) Ask AI using full conversation
        var reply = await _ai.ChatAsync(history, ct);

        // 4) Store assistant reply
        _memory.AppendAssistantMessage(sessionId, reply);

        // 5) Return response
        var response = new ChatResponse
        {
            Reply = reply,
            SessionId = sessionId
        };

        return Ok(response);
    }

    [HttpPost("reset")]
    public IActionResult Reset([FromBody] ChatRequest? request)
    {
        var sessionId = string.IsNullOrWhiteSpace(request?.SessionId)
            ? "default"
            : request!.SessionId!.Trim();

        _memory.Reset(sessionId);

        return NoContent();
    }
}
