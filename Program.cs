using ProjectsQueryAPI.Data;
using ProjectsQueryAPI.Middleware;
using ProjectsQueryAPI.Repositories;
using ProjectsQueryAPI.Services;
using Scalar.AspNetCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// ─── Services ───────────────────────────────────────────────────────────────

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

builder.Services.AddSingleton<DbConnection>();
builder.Services.AddScoped<IProjectQueryRepository, ProjectQueryRepository>();
builder.Services.AddScoped<IProjectQueryService, ProjectQueryService>();

builder.Services.AddOpenApi();

// ─── App ────────────────────────────────────────────────────────────────────

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
