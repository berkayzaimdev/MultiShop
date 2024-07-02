using MultiShop.Order.Application;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Infrastructure.Context;
using MultiShop.Order.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RouteOptions>(
    opts => opts.LowercaseUrls = true
    );

builder.Services.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
builder.Services.AddMediator();
builder.Services.AddDbContext<OrderContext>();

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
