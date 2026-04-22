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
builder.Services.AddScoped<IProductRepository, ProductRepository>();//pendiente
builder.Services.AddScoped<IDbContext, DbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();