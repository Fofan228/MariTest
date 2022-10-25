using FluentValidation;
using Mari.Domain.Entities;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Entities;

public class IssueValidator : AbstractValidator<Issue>
{
    public IssueValidator(
        IValidator<IssueTitle> issueTitleValidator,
        IValidator<IssueLink> issueLinkValidator)
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .SetValidator(issueTitleValidator);
        RuleFor(x => x.Link)
            .NotEmpty()
            .SetValidator(issueLinkValidator);
    }
}
