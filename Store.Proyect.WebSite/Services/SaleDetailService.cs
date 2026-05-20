using System.Net.Http.Json;
using Store.Proyect.WebSite.Dtos;
using Store.Proyect.WebSite.Services.Interfaces;

namespace Store.Proyect.WebSite.Services;

public class SaleDetailService : ISaleDetailService
{
    private readonly HttpClient _httpClient;

    public SaleDetailService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<SaleDetailDto>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<SaleDetailDto>>>("api/SaleDetail");
        return response?.Data ?? new List<SaleDetailDto>();
    }

    public async Task<SaleDetailDto> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<SaleDetailDto>>($"api/SaleDetail/{id}");
        return response?.Data;
    }

    public async Task<SaleDetailDto> AddAsync(SaleDetailDto saleDetail)
    {
        var response = await _httpClient.PostAsJsonAsync("api/SaleDetail", saleDetail);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<SaleDetailDto>>();
        return result?.Data;
    }

    public async Task<SaleDetailDto> UpdateAsync(SaleDetailDto saleDetail)
    {
        var response = await _httpClient.PutAsJsonAsync("api/SaleDetail", saleDetail);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<SaleDetailDto>>();
        return result?.Data;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/SaleDetail/{id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
        return result?.Data ?? false;
    }
}