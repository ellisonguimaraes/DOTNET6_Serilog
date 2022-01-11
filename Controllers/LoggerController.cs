
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("v1/[controller]")]
public class LoggerController : ControllerBase
{
    private readonly ILogger<LoggerController> _logger;

    public LoggerController(ILogger<LoggerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult AddLog()
    {
        _logger.LogInformation("Entrou na AddLog do LoggerController");
        return Ok();
    }
}