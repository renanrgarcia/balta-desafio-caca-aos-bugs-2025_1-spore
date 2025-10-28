using BugStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Services.CreateScope().ServiceProvider
    .GetRequiredService<AppDbContext>().Database.Migrate();

app.MapGet("/", () => "Hello World!");

app.Run();
