using DotNet10Ai.Api.Ai;
using DotNet10Ai.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet10Ai.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IAiInferenceService _ai;

    public ChatController(IAiInferenceService ai)
    {
        _ai = ai;
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponse>> Chat(ChatRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
            return BadRequest("Message cannot be empty.");
        
        var reply = await _ai.ChatAsync(request.Message, HttpContext.RequestAborted);

        return Ok(new ChatResponse { Reply = reply });
    }
}
