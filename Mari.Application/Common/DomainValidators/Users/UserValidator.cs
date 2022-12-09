using FluentValidation;
using Mari.Application.Common.Interfaces.Persistence;
using Mari.Domain.Users;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator(
        IValidator<Username> usernameValidator,
        IValidator<UserId> userIdValidator,
        IUserRepository userRepository)
    {
        RuleFor(u => u.Username)
            .SetValidator(usernameValidator);

        RuleFor(u => u.Id)
            .SetValidator(userIdValidator)
            .MustAsync(async (userId, token) => await userRepository.Exists(userId, token));

        RuleFor(u => u.Role)
            .IsInEnum();
    }
}
