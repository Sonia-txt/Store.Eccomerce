using Store.Proyect.WebSite.Dtos;

namespace Store.Proyect.WebSite.Services.Interfaces;

public interface ISaleDetailService
{
    Task<List<SaleDetailDto>> GetAllAsync();
    Task<SaleDetailDto> GetByIdAsync(int id);
    Task<SaleDetailDto> AddAsync(SaleDetailDto saleDetail);
    Task<SaleDetailDto> UpdateAsync(SaleDetailDto saleDetail);
    Task<bool> DeleteAsync(int id);
}