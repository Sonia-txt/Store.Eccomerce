using Store.Proyect.WebSite.Dtos;

namespace Store.Proyect.WebSite.Services.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync();
    Task<CustomerDto> GetByIdAsync(int id);
    Task<CustomerDto> AddAsync(CustomerDto customer);
    Task<CustomerDto> UpdateAsync(CustomerDto customer);
    Task<bool> DeleteAsync(int id);
}