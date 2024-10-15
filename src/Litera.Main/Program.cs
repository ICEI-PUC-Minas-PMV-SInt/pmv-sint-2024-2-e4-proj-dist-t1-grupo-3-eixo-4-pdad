using Litera.Main.Infrastructure.Database;
using Litera.Main.Models;
using Litera.Main.Repositories;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

string? solutionRoot = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
Env.Load(Path.Combine(solutionRoot, ".env"));


var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? "http://localhost:5160";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins(frontendUrl)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de dados para desenvolvimento
builder.Services.AddDevelopmentDatabaseService();

// Controladores e suporte para Razor Pages
builder.Services.AddControllers();
builder.Services.AddRazorPages(); // Adicionando suporte para Razor Pages

// Injeção para repositórios do DB
builder.Services.AddScoped<ILiteraRepository<AutorModel>, AutorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapRazorPages();

app.Run();
