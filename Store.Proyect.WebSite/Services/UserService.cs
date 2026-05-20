using System.Net.Http.Json;
using Store.Proyect.WebSite.Dtos;
using Store.Proyect.WebSite.Services.Interfaces;

namespace Store.Proyect.WebSite.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<UserDto>>>("api/User");
        return response?.Data ?? new List<UserDto>();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseDto<UserDto>>($"api/User/{id}");
        return response?.Data;
    }

    public async Task<UserDto> AddAsync(UserDto user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/User", user);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<UserDto>>();
        return result?.Data;
    }

    public async Task<UserDto> UpdateAsync(UserDto user)
    {
        var response = await _httpClient.PutAsJsonAsync("api/User", user);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<UserDto>>();
        return result?.Data;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/User/{id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();
        return result?.Data ?? false;
    }
}