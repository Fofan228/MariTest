using System.Data;
using System.Text.RegularExpressions;
using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;

public class IssueValidator : AbstractValidator<Issue>
{
    public static Regex RegexLinkPattern = new Regex(Issue.LinkPattern, RegexOptions.Compiled);

    public IssueValidator()
    {
        RuleFor(i => i.Link)
            .NotEmpty()
            .Must(il => RegexLinkPattern.IsMatch(il));
    }
}
