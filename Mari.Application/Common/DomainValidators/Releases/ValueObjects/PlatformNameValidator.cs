using System.Text.RegularExpressions;
using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;

public class PlatformNameValidator : AbstractValidator<PlatformName>
{
    public static Regex RegexPattern = new Regex(PlatformName.Pattern, RegexOptions.Compiled);

    public PlatformNameValidator()
    {
        RuleFor(pn => pn.Value)
            .NotEmpty()
            .Must(pn => RegexPattern.IsMatch(pn));
    }
}
