namespace Store.Proyect.Api.Repositories.Interfaces;

using Store.Proyect.Core.Entities;
public interface ISaleRepository
{
    //metodo para guardar las categorias 
    Task<Sale> SaveAsync(Sale sale);
    //metodo para actualizar las categorias del producto
    Task<Sale> UpdateAsync(Sale sale);
    //metodo para retornat una lidta de categorias de producto
    Task<List<Sale>> GetAllAsync();
    //metodo para retornar el id de las categorias del producto que se borrara
    Task<bool> DeleteAsync(int id);
    //metodo para obtener una categoria por id
    Task<Sale> GetById(int id);
}