using DotNetEnv;
using Litera.Main.Infrastructure.Database;
using Litera.Main.Models;
using Litera.Main.Repositories;

var builder = WebApplication.CreateBuilder(args);

string? solutionRoot = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
Env.Load(Path.Combine(solutionRoot, ".env"));

var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? "http://localhost:5160";
var databaseUri = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTIONSTRING") ?? null;

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        builder =>
        {
            builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();
        }
    );
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de dados
builder.Services.AddDatabaseService(databaseUri);

// Controladores e suporte para Razor Pages
builder.Services.AddControllers();
builder.Services.AddRazorPages(); // Adicionando suporte para Razor Pages

// Injeção para repositórios do DB
builder.Services.AddScoped<ILiteraRepository<AutorModel>, AutorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthorization();

//app.UseHttpsRedirection();
app.MapControllers();

app.Run();
