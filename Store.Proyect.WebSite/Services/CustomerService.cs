using System.Net.Http.Json;
using Store.Proyect.WebSite.Dtos;
using Store.Proyect.WebSite.Services.Interfaces;

namespace Store.Proyect.WebSite.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<CustomerDto>>>("api/Customer");
        return response?.Data ?? new List<CustomerDto>();
    }

    public async Task<CustomerDto> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<CustomerDto>>($"api/Customer/{id}");
        return response?.Data;
    }

    public async Task<CustomerDto> AddAsync(CustomerDto customer)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Customer", customer);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<CustomerDto>>();
        return result?.Data;
    }

    public async Task<CustomerDto> UpdateAsync(CustomerDto customer)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Customer", customer);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<CustomerDto>>();
        return result?.Data;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Customer/{id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
        return result?.Data ?? false;
    }
}