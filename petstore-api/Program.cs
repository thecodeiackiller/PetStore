using Microsoft.EntityFrameworkCore;
using Petstore.Data;
using Petstore.Data.Repositories;
using Petstore.MappingProfiles;
using Petstore.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Create a variable which is going to store the connection string
// Create a service for the dbcontext and specify were using Sqlite (if that's possible)
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

var connectionString = @"Data Source=C:\Users\knunn\Documents\Projects\PetShop\Petstore\bin\Debug\net8.0\products.db";
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlite(connectionString));
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
