using DotNetEnv;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

string solutionRoot = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
Env.Load(Path.Combine(solutionRoot, ".env"));

var apiUrl = Environment.GetEnvironmentVariable("API_URL") ?? "http://localhost:5233";


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
