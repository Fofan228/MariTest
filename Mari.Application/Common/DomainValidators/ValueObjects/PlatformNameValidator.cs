using System.Text.RegularExpressions;
using FluentValidation;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.ValueObjects;

public class PlatformNameValidator : AbstractValidator<PlatformName>
{
    public static readonly Regex PlatformNameRegex = new(PlatformName.Pattern, RegexOptions.Compiled);
    public PlatformNameValidator()
    {
        RuleFor(pn => pn.Value)
            .NotEmpty()
            .Matches(PlatformNameRegex)
            .OverridePropertyName(nameof(PlatformName));
    }
}