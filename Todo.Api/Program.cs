using Todo.Application.Services;
using Todo.Domain.Interfaces;
using Todo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In-memory Database
builder.Services.AddDbContext<TodoTaskDbContext>(options =>
{
    options.UseInMemoryDatabase("TodoTaskInventoryDb");
});

// Dependency Injection for in-memory DB and services
builder.Services.AddScoped<ITodoTaskRepository, InMemoryTodoTaskRepository>();
builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    // configures Automapper to map DTO to Entity

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
