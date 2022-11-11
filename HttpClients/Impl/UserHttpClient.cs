using HttpClients.ClientInterfaces;
using Domain.Models;
using Domain.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace HttpClients.Impl;

public class UserHttpClient : IUserService
{

    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> Create(UserDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/user", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }

    public async Task<User> Login(UserDto dto)
    {
        HttpResponseMessage respone = await client.PostAsJsonAsync("/login", dto);
        string result = await respone.Content.ReadAsStringAsync();
        if (!respone.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return user;
    }
}