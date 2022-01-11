using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration() 
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
