using FluentValidation;
using Mari.Domain.Releases.Entities;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.Entities;

public class PlatformValidator : AbstractValidator<Platform>
{
    public PlatformValidator(IValidator<PlatformName> platformNameValidator)
    {
        RuleFor(p => p.Name)
            .SetValidator(platformNameValidator);
    }
}
