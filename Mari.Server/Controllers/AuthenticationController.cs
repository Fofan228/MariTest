using System.Security.Claims;
using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Mari.Server.Authentication.Configurations;
using MediatR;
using Mari.Application.Authentication.Queries.Login;
using Mari.Contracts.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Mari.Application.Users.Queries.Exists;
using Mari.Application.Authentication.Commands.Registration;
using Mari.Application.Authentication.Results;
using ErrorOr;

namespace Mari.Server.Controllers;

[Route(Routes.Server.AuthorizationController)]
public class AuthorizationController : ApiController
{
    private readonly ISender _sender;

    public AuthorizationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = $"{CookieConfig.AuthenticationScheme}, {OAuthConfig.AuthenticationScheme}")]
    public async Task<IActionResult> GetToken(/*AuthenticationRequest request*/)
    {
        var request = new AuthenticationRequest("http://localhost:5001/token");

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
            return Redirect($"{request.redirectUrl}?token={authResult.Value.Token}");
        }

        var registrationCommand = new RegistrationCommand(userId, userName);
        authResult = await _sender.Send(registrationCommand);
        if (authResult.IsError) return Problem(authResult.Errors);
        return Redirect($"{request.redirectUrl}?token={authResult.Value.Token}");
    }

    //TODO Тестовый метод
    [AllowAnonymous]
    [HttpGet("/token")]
    public IEnumerable<Claim> Get(string token)
    {
        var jwtToken = new JwtSecurityToken(token);
        return jwtToken.Claims;
    }
}
