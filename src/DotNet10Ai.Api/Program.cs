using DotNet10Ai.Api.Ai;
using DotNet10Ai.Api.Ai.Ollama;
using DotNet10Ai.Api.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AiOptions>(
    builder.Configuration.GetSection("Ai"));

builder.Services.AddHttpClient<OllamaInferenceService>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptionsMonitor<AiOptions>>();
    client.BaseAddress = new Uri(options.CurrentValue.Local.OllamaUrl);
});



builder.Services.AddScoped<IAiInferenceService, OllamaInferenceService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
