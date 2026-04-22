using Dapper;
using Store.Proyect.Core.Entities;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Api.DataAccess.Interfaces;

namespace Store.Proyect.Api.Repositories;

public class SaleDetailRepository : ISaleDetailRepository
{
    private readonly IDbContext _dbContext;
    public SaleDetailRepository(IDbContext context) => _dbContext = context;

    public async Task<SaleDetail> SaveAsync(SaleDetail detail)
    {
        var sql = "INSERT INTO SaleDetails (sale_id, product_id, quantity, unit_price, subtotal, is_deleted, created_by, created_date) VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice, @Subtotal, 0, @CreatedBy, @CreatedDate); SELECT LAST_INSERT_ID();";
        detail.Id = await _dbContext.Connection.ExecuteScalarAsync<int>(sql, detail);
        return detail;
    }

    public async Task<SaleDetail> UpdateAsync(SaleDetail detail)
    {
        var sql = "UPDATE SaleDetails SET quantity = @Quantity, unit_price = @UnitPrice, subtotal = @Subtotal, updated_by = @UpdatedBy, updated_date = @UpdatedDate WHERE id = @Id";
        await _dbContext.Connection.ExecuteAsync(sql, detail);
        return detail;
    }

    public async Task<List<SaleDetail>> GetAllAsync()
    {
        var sql = "SELECT id as Id, sale_id as SaleId, product_id as ProductId, quantity as Quantity, unit_price as UnitPrice, subtotal as Subtotal FROM SaleDetails WHERE is_deleted = 0";
        var result = await _dbContext.Connection.QueryAsync<SaleDetail>(sql);
        return result.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "UPDATE SaleDetails SET is_deleted = 1 WHERE id = @Id";
        var result = await _dbContext.Connection.ExecuteAsync(sql, new { Id = id });
        return result > 0;
    }

    public async Task<SaleDetail> GetById(int id)
    {
        var sql = "SELECT id as Id, sale_id as SaleId, product_id as ProductId, quantity as Quantity, unit_price as UnitPrice, subtotal as Subtotal FROM SaleDetails WHERE id = @Id AND is_deleted = 0";
        return await _dbContext.Connection.QueryFirstOrDefaultAsync<SaleDetail>(sql, new { Id = id });
    }
}