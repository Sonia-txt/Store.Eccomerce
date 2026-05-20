using System.Net.Http.Json;
using Store.Proyect.WebSite.Dtos;
using Store.Proyect.WebSite.Services.Interfaces;

namespace Store.Proyect.WebSite.Services;

public class SaleService : ISaleService
{
    private readonly HttpClient _httpClient;

    public SaleService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<SaleDto>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<SaleDto>>>("api/Sale");
        return response?.Data ?? new List<SaleDto>();
    }

    public async Task<SaleDto> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<SaleDto>>($"api/Sale/{id}");
        return response?.Data;
    }

    public async Task<SaleDto> AddAsync(SaleDto sale)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Sale", sale);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<SaleDto>>();
        return result?.Data;
    }

    public async Task<SaleDto> UpdateAsync(SaleDto sale)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Sale", sale);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<SaleDto>>();
        return result?.Data;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Sale/{id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
        return result?.Data ?? false;
    }
}