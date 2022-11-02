using System.Text.RegularExpressions;
using FluentValidation;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Users.ValueObjects;

public class UsernameValidator : AbstractValidator<Username>
{
    public static Regex RegexPattern = new Regex(Username.Pattern, RegexOptions.Compiled);

    public UsernameValidator()
    {
        RuleFor(un => un.Value)
            .NotEmpty()
            .Must(x => RegexPattern.IsMatch(x));
    }
}
