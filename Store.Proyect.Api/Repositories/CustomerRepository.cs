using Dapper;
using Store.Proyect.Core.Entities;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Api.DataAccess.Interfaces;

namespace Store.Proyect.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbContext _dbContext;
    public CustomerRepository(IDbContext context) => _dbContext = context;

    public async Task<Customer> SaveAsync(Customer customer)
    {
        
        var sql = @"INSERT INTO Customers (name, email, phone, address, is_deleted) 
                    VALUES (@Name, @Email, @Phone, @Address, 0); 
                    SELECT LAST_INSERT_ID();";
        
        customer.Id = await _dbContext.Connection.ExecuteScalarAsync<int>(sql, customer);
        return customer;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        var sql = "SELECT id as Id, name as Name, email as Email, phone as Phone, address as Address, is_deleted as IsDeleted FROM Customers WHERE is_deleted = 0";
        var result = await _dbContext.Connection.QueryAsync<Customer>(sql);
        return result.ToList();
    }

    public async Task<Customer?> GetById(int id)
    {
        var sql = "SELECT id as Id, name as Name, email as Email, phone as Phone, address as Address, is_deleted as IsDeleted FROM Customers WHERE id = @Id AND is_deleted = 0";
        return await _dbContext.Connection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        var sql = "UPDATE Customers SET name = @Name, email = @Email, phone = @Phone, address = @Address WHERE id = @Id";
        await _dbContext.Connection.ExecuteAsync(sql, customer);
        return customer;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "UPDATE Customers SET is_deleted = 1 WHERE id = @Id";
        var result = await _dbContext.Connection.ExecuteAsync(sql, new { Id = id });
        return result > 0;
    }
}