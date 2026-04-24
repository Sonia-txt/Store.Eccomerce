using Store.Proyect.Api.DataAccess.Interfaces;
using Store.Proyect.Api.Repositories;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Api.DataAccess; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddSingleton<IProductCategoryRepository, InMemoryProductCategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();         
builder.Services.AddScoped<ISaleRepository, SaleRepository>();        
builder.Services.AddScoped<ISaleDetailRepository, SaleDetailRepository>(); 


builder.Services.AddScoped<IDbContext, Store.Proyect.Api.DataAccess.StoreDbContext>();
builder.Services.AddScoped<IDbContext, StoreDbContext>();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();