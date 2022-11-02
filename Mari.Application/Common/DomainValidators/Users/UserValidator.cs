using FluentValidation;
using Mari.Domain.Users;

namespace Mari.Application.Common.DomainValidators.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Role)
            .IsInEnum();
    }
}
