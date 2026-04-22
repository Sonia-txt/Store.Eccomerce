using Dapper;
using Store.Proyect.Core.Entities;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Api.DataAccess.Interfaces;

namespace Store.Proyect.Api.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly IDbContext _dbContext;
    public SaleRepository(IDbContext context) => _dbContext = context;

    public async Task<Sale> SaveAsync(Sale sale)
    {
        var sql = "INSERT INTO Sales (customer_id, sale_date, total_amount, status, is_deleted, created_by, created_date) VALUES (@CustomerId, @SaleDate, @TotalAmount, @Status, 0, @CreatedBy, @CreatedDate); SELECT LAST_INSERT_ID();";
        sale.Id = await _dbContext.Connection.ExecuteScalarAsync<int>(sql, sale);
        return sale;
    }

    public async Task<Sale> UpdateAsync(Sale sale)
    {
        var sql = "UPDATE Sales SET customer_id = @CustomerId, total_amount = @TotalAmount, status = @Status, updated_by = @UpdatedBy, updated_date = @UpdatedDate WHERE id = @Id";
        await _dbContext.Connection.ExecuteAsync(sql, sale);
        return sale;
    }

    public async Task<List<Sale>> GetAllAsync()
    {
        var sql = "SELECT id as Id, customer_id as CustomerId, sale_date as SaleDate, total_amount as TotalAmount, status as Status FROM Sales WHERE is_deleted = 0";
        var result = await _dbContext.Connection.QueryAsync<Sale>(sql);
        return result.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "UPDATE Sales SET is_deleted = 1 WHERE id = @Id";
        var result = await _dbContext.Connection.ExecuteAsync(sql, new { Id = id });
        return result > 0;
    }

    public async Task<Sale> GetById(int id)
    {
        var sql = "SELECT id as Id, customer_id as CustomerId, sale_date as SaleDate, total_amount as TotalAmount, status as Status FROM Sales WHERE id = @Id AND is_deleted = 0";
        return await _dbContext.Connection.QueryFirstOrDefaultAsync<Sale>(sql, new { Id = id });
    }
}