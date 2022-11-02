using FluentValidation;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Users.ValueObjects;

public class UserIdValidator : AbstractValidator<UserId>
{
    public UserIdValidator()
    {
        RuleFor(ui => ui.Value)
            .NotEmpty();
    }
}
