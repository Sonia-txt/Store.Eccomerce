using System.Net.Http.Json;
using Store.Proyect.WebSite.Dtos;
using Store.Proyect.WebSite.Services.Interfaces;

namespace Store.Proyect.WebSite.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<ProductDto>>>("api/Product");
        return response?.Data ?? new List<ProductDto>();
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<ProductDto>>($"api/Product/{id}");
        return response?.Data;
    }

    public async Task<ProductDto> AddAsync(ProductDto product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Product", product);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<ProductDto>>();
        return result?.Data;
    }

    public async Task<ProductDto> UpdateAsync(ProductDto product)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Product", product);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<ProductDto>>();
        return result?.Data;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Product/{id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
        return result?.Data ?? false;
    }
}