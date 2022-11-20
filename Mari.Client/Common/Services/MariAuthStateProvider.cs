using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using Mari.Client.Common.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Mari.Client.Common.Services;

public class MariAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;

    public MariAuthStateProvider(
        ILocalStorageService localStorage,
        HttpClient httpClient)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
    }

    private AuthenticationState Anonymous => new(new ClaimsPrincipal(new ClaimsIdentity()));

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenStr = await _localStorage.GetItemAsync<string>("authToken");
        if (tokenStr is null) return Anonymous;

        var tokenHandler = new JsonWebTokenHandler();
        if (!tokenHandler.CanReadToken(tokenStr)) return Anonymous;
        var token = tokenHandler.ReadJsonWebToken(tokenStr);

        if (token.ValidTo < DateTime.UtcNow)
        {
            return Anonymous;
        }

        var user = CreateUser(token);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenStr);

        return new AuthenticationState(user);
    }

    public void UpdateAuthenticationState()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private ClaimsPrincipal CreateUser(JsonWebToken token)
    {
        return new(new ClaimsIdentity(
            claims: token.Claims,
            authenticationType: JwtConstants.TokenType,
            nameType: JwtRegisteredClaimNames.Name,
            roleType: ClaimTypes.Role));
    }
}