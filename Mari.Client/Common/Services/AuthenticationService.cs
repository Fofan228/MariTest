using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using Mari.Client.Common.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Mari.Contracts.Authentication;
using Mari.Contracts.Common.Routes.Client;

namespace Mari.Client.Common.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorage;
    private readonly MariAuthStateProvider _authenticationStateProvider;

    public AuthenticationService(
        NavigationManager navigationManager,
        ILocalStorageService localStorage,
        AuthenticationStateProvider authenticationStateProvider)
    {
        _navigationManager = navigationManager;
        _localStorage = localStorage;
        _authenticationStateProvider = (MariAuthStateProvider)authenticationStateProvider;
    }

    public void Authenticate()
    {
        var request = new AuthenticationRequest(_navigationManager.BaseUri.TrimEnd('/') + ClientRoutes.Pages.TokenHandler);
        var builder = new UriBuilder(_navigationManager.BaseUri)
        {
            Path = request.GetRoute(),
            Query = request.GetQueryString()
        };
        _navigationManager.NavigateTo(builder.Uri.ToString(), true);
    }

    public async Task LoginAsync(string token)
    {
        await _localStorage.SetItemAsync(LocalStorageKeys.Authentication.Token, token);
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync(LocalStorageKeys.Authentication.Token);
        _authenticationStateProvider.UpdateAuthenticationState();
    }
}