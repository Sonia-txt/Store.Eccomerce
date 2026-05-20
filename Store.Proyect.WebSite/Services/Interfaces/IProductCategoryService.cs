using Store.Proyect.WebSite.Dtos;

namespace Store.Proyect.WebSite.Services.Interfaces;

public interface IProductCategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
    Task<CategoryDto> AddAsync(CategoryDto category);
    Task UpdateAsync(CategoryDto category);
    Task DeleteAsync(int id);
}