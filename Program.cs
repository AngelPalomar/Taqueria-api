using Microsoft.EntityFrameworkCore;
using Taqueria.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Data>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
