using Dapper;
using System.Data;
using Store.Proyect.Core.Entities;
using Store.Proyect.Api.DataAccess.Interfaces;
using Store.Proyect.Api.Repositories.Interfaces;

namespace Store.Proyect.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbContext _dbContext;
    public ProductRepository(IDbContext context) => _dbContext = context;

    public async Task<Product> SaveAsync(Product product)
    {
        var sql = @"INSERT INTO Products 
        (name, description, price, stock, is_active, is_deleted) 
        VALUES (@Name, @Description, @Price, @Stock, @IsActive, 0); 
        SELECT LAST_INSERT_ID();";

        product.Id = await _dbContext.Connection.ExecuteScalarAsync<int>(sql, product);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        var sql = @"UPDATE Products 
        SET name = @Name, 
            description = @Description, 
            price = @Price, 
            stock = @Stock, 
            is_active = @IsActive, 
            category_id = @CategoryId 
        WHERE id = @Id";

        await _dbContext.Connection.ExecuteAsync(sql, product);
        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var sql = @"SELECT 
            id as Id, 
            name as Name, 
            description as Description, 
            price as Price, 
            stock as Stock, 
            is_active as IsActive,
            category_id as CategoryId
        FROM Products 
        WHERE is_deleted = 0";

        var result = await _dbContext.Connection.QueryAsync<Product>(sql);
        return result.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "UPDATE Products SET is_deleted = 1 WHERE id = @Id";
        var result = await _dbContext.Connection.ExecuteAsync(sql, new { Id = id });
        return result > 0;
    }

    public async Task<Product?> GetById(int id)
    {
        var sql = @"SELECT 
            id as Id, 
            name as Name, 
            description as Description, 
            price as Price, 
            stock as Stock, 
            is_active as IsActive,
            category_id as CategoryId
        FROM Products 
        WHERE id = @Id AND is_deleted = 0";

        return await _dbContext.Connection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
    }
}