using FluentValidation;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Application.Users.Queries.Exists;

internal class UserExistsQueryValidator : AbstractValidator<UserExistsQuery>
{
    public UserExistsQueryValidator(IValidator<UserId> userIdValidator)
    {
        RuleFor(x => x.UserId)
            .SetValidator(userIdValidator);
    }
}
