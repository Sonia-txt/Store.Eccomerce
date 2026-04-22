using Dapper;
using Store.Proyect.Core.Entities;
using Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Api.DataAccess.Interfaces;

namespace Store.Proyect.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;
    public UserRepository(IDbContext context) => _dbContext = context;

    public async Task<User> SaveAsync(User user)
    {
        var sql = "INSERT INTO Users (name, email, password, is_deleted, created_by, created_date) VALUES (@Name, @Email, @Password, 0, @CreatedBy, @CreatedDate); SELECT LAST_INSERT_ID();";
        user.Id = await _dbContext.Connection.ExecuteScalarAsync<int>(sql, user);
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var sql = "UPDATE Users SET name = @Name, email = @Email, password = @Password, updated_by = @UpdatedBy, updated_date = @UpdatedDate WHERE id = @Id";
        await _dbContext.Connection.ExecuteAsync(sql, user);
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var sql = "SELECT id as Id, name as Name, email as Email, password as Password FROM Users WHERE is_deleted = 0";
        var result = await _dbContext.Connection.QueryAsync<User>(sql);
        return result.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "UPDATE Users SET is_deleted = 1 WHERE id = @Id";
        var result = await _dbContext.Connection.ExecuteAsync(sql, new { Id = id });
        return result > 0;
    }

    public async Task<User> GetById(int id)
    {
        var sql = "SELECT id as Id, name as Name, email as Email, password as Password FROM Users WHERE id = @Id AND is_deleted = 0";
        return await _dbContext.Connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }
}