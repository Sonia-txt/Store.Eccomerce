namespace Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Core.Entities;

public interface IProductRepository
{
    //metodo para guardar las categorias del 
    Task<Product> SaveAsync(Product product);
    //metodo para actualizar las categorias del producto
    Task<Product> UpdateAsync(Product product);
    //metodo para retornat una lidta de categorias de producto
    Task<List<Product>> GetAllAsync();
    //metodo para retornar el id de las categorias del producto que se borrara
    Task<bool> DeleteAsync(int id);
    //metodo para obtener una categoria por id
    Task<Product> GetById(int id);
}