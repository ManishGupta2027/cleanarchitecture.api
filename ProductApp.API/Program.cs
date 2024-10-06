using Microsoft.EntityFrameworkCore;
using ProductApp.Infrastructure;
using MediatR;
using ProductApp.Application;
using AutoMapper;
using ProductApp.Infrastructure.Data;
using ProductApp.Application.Mappings;
using ProductApp.Application.Services.Products;
using ProductApp.Infrastructure.Repositories.Products;
using ProductApp.Domain.Repositories.Products;
using ProductApp.Domain.Repositories.Brands;
using ProductApp.Infrastructure.Repositories.Brands;
using ProductApp.Application.Services.Brands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(ApplicationAssemblyMarker).Assembly);
builder.Services.AddAutoMapper(typeof(ApplicationAssemblyMarker).Assembly);

builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddAutoMapper(typeof(BrandProfile));
// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();


// Add Swagger for API documentation
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
