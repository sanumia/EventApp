using EventsApp.Application;
using EventsApp.DataAccess;
using EventsApp.DataAccess.Interfaces;
using EventsApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection));
builder.Services.AddDataAccess();


builder.Services.AddBussinessLogic();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
