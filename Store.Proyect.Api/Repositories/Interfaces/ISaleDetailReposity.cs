namespace Store.Proyect.Api.Repositories.Interfaces;

using Store.Proyect.Core.Entities;
public interface ISaleDetailRepository
{
    //metodo para guardar las categorias del 
    Task<SaleDetail> SaveAsync(SaleDetail saleDetail);
    //metodo para actualizar las categorias del producto
    Task<SaleDetail> UpdateAsync(SaleDetail saleDetail);
    //metodo para retornat una lidta de categorias de producto
    Task<List<SaleDetail>> GetAllAsync();
    //metodo para retornar el id de las categorias del producto que se borrara
    Task<bool> DeleteAsync(int id);
    //metodo para obtener una categoria por id
    Task<SaleDetail> GetById(int id);
}