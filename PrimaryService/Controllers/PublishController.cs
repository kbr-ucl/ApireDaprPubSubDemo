using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace PrimaryService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishController : ControllerBase
{
    private readonly DaprClient _daprClient;
    private readonly ILogger<PublishController> _logger;

    public PublishController(ILogger<PublishController> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _daprClient.PublishEventAsync("order", "A", new MessageEvent("order", "This is a test message"));
        return Ok();
    }
}

public record MessageEvent(string MessageType, string Message);