using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();
}

// Health endpoint
app.MapGet("/", () => Results.Ok(new
{
    name = "DotNet10 AI Starter",
    status = "running",
    runtime = ".NET 10"
}));

app.Run();
