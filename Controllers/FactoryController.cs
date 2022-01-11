
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("v1/[controller]")]
public class FactoryController : ControllerBase
{
    private readonly ILogger _logger;
    // ou private readonly ILogger<FactoryController> _logger;

    public FactoryController(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FactoryController>();
        // ou _logger = loggerFactory.CreateLogger("LoggerController");
    }

    [HttpGet]
    public IActionResult AddLog()
    {
        _logger.LogInformation("Entrou na AddLog do FactoryController");
        return Ok();
    }
}