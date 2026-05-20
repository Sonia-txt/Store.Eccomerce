using Store.Proyect.WebSite.Dtos;

namespace Store.Proyect.WebSite.Services.Interfaces;

public interface ISaleService
{
    Task<List<SaleDto>> GetAllAsync();
    Task<SaleDto> GetByIdAsync(int id);
    Task<SaleDto> AddAsync(SaleDto sale);
    Task<SaleDto> UpdateAsync(SaleDto sale);
    Task<bool> DeleteAsync(int id);
}