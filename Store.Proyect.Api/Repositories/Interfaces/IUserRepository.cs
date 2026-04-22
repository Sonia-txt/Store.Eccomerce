namespace Store.Proyect.Api.Repositories.Interfaces;
using Store.Proyect.Core.Entities;
public interface IUserRepository
{
    //metodo para guardar las categorias 
    Task<User> SaveAsync(User user);
    //metodo para actualizar las categorias del producto
    Task<User> UpdateAsync(User user);
    //metodo para retornat una lidta de categorias de producto
    Task<List<User>> GetAllAsync();
    //metodo para retornar el id de las categorias del producto que se borrara
    Task<bool> DeleteAsync(int id);
    //metodo para obtener una categoria por id
    Task<User> GetById(int id);
}