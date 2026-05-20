using Store.Proyect.WebSite.Dtos;

namespace Store.Proyect.WebSite.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> AddAsync(UserDto user);
    Task<UserDto> UpdateAsync(UserDto user);
    Task<bool> DeleteAsync(int id);
}