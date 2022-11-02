using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;
public class ReleaseIdValidator : AbstractValidator<ReleaseId>
{
    public ReleaseIdValidator()
    {
        RuleFor(ri => ri.Value)
            .NotEmpty();
    }
}
