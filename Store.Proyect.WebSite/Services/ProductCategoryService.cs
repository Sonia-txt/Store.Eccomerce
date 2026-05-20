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
        return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("api/Category");
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<CategoryDto>($"api/Category/{id}");
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