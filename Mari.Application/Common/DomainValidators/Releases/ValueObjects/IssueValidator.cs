using FluentValidation;
using Mari.Application.Common.DomainValidators.Shared;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;

public class IssueValidator : StringAbstractValidator<Issue>
{
    public IssueValidator() : base()
    {
        RuleFor(i => i.Value)
            .Must(i => Uri.IsWellFormedUriString(i, UriKind.Absolute));
    }
}
