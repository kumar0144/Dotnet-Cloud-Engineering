using Microsoft.EntityFrameworkCore;
using Product.API.Application.Interfaces;
using Product.API.Application.Services;
using Product.API.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//connection string for sql server
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// ==========================================
// 🛠️ PLACE YOUR DEPENDENCY INJECTIONS HERE!
// ==========================================
builder.Services.AddScoped<IProductService, ProductService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
