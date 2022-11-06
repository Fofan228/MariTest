using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Mari.Client.Services;

public class MariAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;

    public MariAuthStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    private AuthenticationState Anonymous => new(new ClaimsPrincipal(new ClaimsIdentity()));

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenStr = await _localStorage.GetItemAsync<string>("authToken");
        if (tokenStr is null) return Anonymous;
        var tokenHandler = new JsonWebTokenHandler();
        if (!tokenHandler.CanReadToken(tokenStr)) return Anonymous;
        var token = tokenHandler.ReadJsonWebToken(tokenStr);
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaims(token.Claims);
        return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
    }
}
