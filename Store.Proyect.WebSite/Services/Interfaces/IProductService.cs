using Store.Proyect.WebSite.Dtos;

namespace Store.Proyect.WebSite.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(int id);
    Task<ProductDto> AddAsync(ProductDto product);
    Task<ProductDto> UpdateAsync(ProductDto product);
    Task<bool> DeleteAsync(int id);
}