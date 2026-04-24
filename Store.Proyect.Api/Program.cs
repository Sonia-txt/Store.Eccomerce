using System.Data;
using Store.Proyect.Api.DataAccess;
using Store.Proyect.Api.DataAccess.Interfaces;
using Store.Proyect.Api.Repositories;
using Store.Proyect.Core.Interfaces;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Infrastructure.Repositories;
using ProductRepository = Store.Proyect.Api.Repositories.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDbContext, StoreDbContext>();


builder.Services.AddScoped<IDbConnection>(sp => 
{
    var context = sp.GetRequiredService<IDbContext>();
    return context.Connection;
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();