using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWASM;

public class AuthProvider : AuthenticationStateProvider
{

    private readonly ILocalStorageService _localStorage;

    public AuthProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new ClaimsPrincipal());

        string username = await _localStorage.GetItemAsync<string>("user");
        if (!string.IsNullOrEmpty(username))
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }, "test authentication type"
            );

            state = new AuthenticationState(new ClaimsPrincipal(identity));
        }

        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }
}