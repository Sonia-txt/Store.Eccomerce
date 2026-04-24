using Dapper;
using System.Data;
using Store.Proyect.Core.Entities;
using Store.Proyect.Core.Interfaces;

namespace Store.Proyect.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _db;

    public CategoryRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<Category> AddAsync(Category category)
    {
        const string sql = @"
            INSERT INTO categories (name, is_deleted, created_by, created_date) 
            VALUES (@name, @IsDeleted, @CreatedBy, @CreatedDate);
            SELECT LAST_INSERT_ID();";

        var newId = await _db.ExecuteScalarAsync<int>(sql, category);
        
        category.Id = newId; 
        
        return category;
    }

    public async Task<Category?> UpdateAsync(Category category)
    {
        const string sql = @"
            UPDATE categories 
            SET name = @name, 
                updated_by = @UpdatedBy, 
                updated_date = NOW() 
            WHERE id = @Id AND is_deleted = 0";

        await _db.ExecuteAsync(sql, category);
        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        const string sql = "SELECT * FROM categories WHERE is_deleted = 0";
        var result = await _db.QueryAsync<Category>(sql);
        return result.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "UPDATE categories SET is_deleted = 1, updated_date = NOW() WHERE id = @Id AND is_deleted = 0";
        var result = await _db.ExecuteAsync(sql, new { Id = id });
        return result > 0;
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM categories WHERE id = @Id AND is_deleted = 0";
        return await _db.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
    }
}