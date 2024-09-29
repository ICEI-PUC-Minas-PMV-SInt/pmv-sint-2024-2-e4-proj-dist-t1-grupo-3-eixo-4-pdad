using Litera.Main.Infrastructure.Database;
using Litera.Main.Models;
using Litera.Main.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco de dados para desenvolvimento
builder.Services.AddDevelopmentDatabaseService();

// Controladores
builder.Services.AddControllers();

// Injeção para repositóridos do DB
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

app.Run();
