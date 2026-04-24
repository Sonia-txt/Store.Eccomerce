// Store.Proyect.Core.Interfaces

using Store.Proyect.Core.Entities;

namespace Store.Proyect.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task<int> AddAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(int id); // Soft delete sugerido por IsDeleted
}

public interface ICartItemRepository
{
    Task<IEnumerable<CartItem>> GetByCartIdAsync(int cartId);
    Task<int> AddAsync(CartItem item);
    Task<bool> DeleteAsync(int id);
}