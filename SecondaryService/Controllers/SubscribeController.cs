using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace SecondaryService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController : ControllerBase
{
    private readonly ILogger<SubscribeController> _logger;

    public SubscribeController(ILogger<SubscribeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Topic("order", "A")]
    public IActionResult Post(MessageEvent item)
    {
        _logger.LogInformation($"{item.MessageType}: {item.Message}");
        return Ok();
    }
}

public record MessageEvent(string MessageType, string Message);