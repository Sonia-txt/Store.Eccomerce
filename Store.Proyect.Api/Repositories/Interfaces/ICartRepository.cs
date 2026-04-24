using Store.Proyect.Core.Entities;

namespace Store.Proyect.Api.Repositories.Interfaces;

public interface ICartRepository
{
    Task<string> AddToCartAsync(CartItem item);
    Task<object> GetCartTotalAsync();
    Task<bool> DeleteItemAsync(int id);
    Task<bool> ClearCartAsync();
}