using API;
using Application;
using Application.Common.Interfaces;
using Application.Game.Utils;
using Infrastructure;
using Infrastructure.Repository;
using Infrastructure.RepositoryOperations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject dependences
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplication();
builder.Services.AddScoped<ICreateGameDbContext, CreateGameDbContext>();
builder.Services.AddTransient<INewBoard, NewBoard>();
builder.Services.AddTransient<INextBoardDbContext, NextBoardDbContext>();


// BD
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
