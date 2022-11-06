using System.Security.Claims;
using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Mari.Server.Authentication.Configurations;
using MediatR;
using Mari.Application.Authentication.Queries.Login;
using Mari.Contracts.Authentication;
using Mari.Application.Users.Queries.Exists;
using Mari.Application.Authentication.Commands.Registration;
using Mari.Application.Authentication.Results;
using ErrorOr;
using Mari.Server.Settings;
using Microsoft.Extensions.Options;

namespace Mari.Server.Controllers;

[Route(Routes.Server.AuthenticationController)]
public class AuthorizationController : ApiController
{
    private readonly ISender _sender;
    private readonly HostSettings _hostSettings;

    public AuthorizationController(ISender sender, IOptions<HostSettings> hostSettings)
    {
        _sender = sender;
        _hostSettings = hostSettings.Value;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = $"{CookieConfig.AuthenticationScheme}, {OAuthConfig.AuthenticationScheme}")]
    public async Task<IActionResult> GetToken()
    {
        var userIdClaim = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

        var userName = User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        var userId = int.Parse(userIdClaim);

        var existsQuery = new UserExistsQuery(userId);
        var existsResult = await _sender.Send(existsQuery);
        if (existsResult.IsError) return Problem(existsResult.Errors);

        ErrorOr<AuthenticationResult> authResult;

        if (existsResult.Value)
        {
            var loginQuery = new LoginQuery(userId);
            authResult = await _sender.Send(loginQuery);
            if (authResult.IsError) return Problem(authResult.Errors);
        }
        else
        {
            var registrationCommand = new RegistrationCommand(userId, userName);
            authResult = await _sender.Send(registrationCommand);
            if (authResult.IsError) return Problem(authResult.Errors);
        }

        var request = new AuthenticationRequest(authResult.Value.Token);
        var builder = new UriBuilder
        {
            Path = $"{_hostSettings.Host}{Routes.Client.TokenHandler}",
            Query = request.ToUrlEncodedQuery()
        };
        return Redirect(builder.Uri.ToString());
    }
}
