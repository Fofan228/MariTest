using Mari.Application.Authentication.Results;
using Mari.Application.Common.Interfaces.Authentication;
using Mari.Domain.Entities;
using Mari.Domain.Enums;
using Mari.Domain.ValueObjects;
using MediatR;

namespace Mari.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        //TODO Репозиторий
        var user = User.Create(Username.Create("test_user_admin"), UserRole.Admin);
        var token = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult(new AuthenticationResult(token));
    }
}
