using System.Text.RegularExpressions;
using FluentValidation;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.ValueObjects;

public class IssueLinkValidator : AbstractValidator<IssueLink>
{
    public static readonly Regex IssueLinkRegex = new(IssueLink.Pattern, RegexOptions.Compiled);
    public IssueLinkValidator()
    {
        RuleFor(il => il.Value)
            .NotEmpty()
            .Matches(IssueLinkRegex)
            .OverridePropertyName(nameof(IssueLink));
    }
}