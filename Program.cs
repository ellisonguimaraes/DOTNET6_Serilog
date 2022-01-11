using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

// Remove default logging providers
builder.Logging.ClearProviders();

// Serilog configuration		
var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
    .WriteTo.Seq("http://localhost:5341/")
    .CreateLogger();

// Register Serilog
builder.Logging.AddSerilog(logger);

// Add Controllers
builder.Services.AddControllers();


var app = builder.Build();

// Map Controllers
app.MapControllers();

app.MapGet("/v1/minimalapi", (ILoggerFactory loggerFactory) => {
    var logger = loggerFactory.CreateLogger("MinimalAPI Log");
    logger.LogInformation("Entrou na rota MinimalAPI /v1/minimalapi");
});

app.Run();
