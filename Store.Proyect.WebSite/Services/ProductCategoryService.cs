using System.Net.Http.Json;
using Store.Proyect.WebSite.Dtos;
using Store.Proyect.WebSite.Services.Interfaces;

namespace Store.Proyect.WebSite.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly HttpClient _httpClient;

    public ProductCategoryService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        // Cambiado para leer directamente el array enviado por tu CategoryController
        var categories = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("api/Category");
        return categories ?? new List<CategoryDto>();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _httpClient.GetFromJsonAsync<CategoryDto>($"api/Category/{id}");
        return category;
    }

    public async Task<CategoryDto> AddAsync(CategoryDto category)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Category", category);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CategoryDto>();
    }

    public async Task UpdateAsync(CategoryDto category)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Category", category);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Category/{id}");
        response.EnsureSuccessStatusCode();
    }
}