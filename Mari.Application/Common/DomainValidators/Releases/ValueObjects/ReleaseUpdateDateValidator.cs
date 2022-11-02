using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;

public class ReleaseUpdateDateValidator : AbstractValidator<ReleaseUpdateDate>
{
    public ReleaseUpdateDateValidator()
    {
        RuleFor(rud => rud.Value)
            .NotEmpty();
    }
}
