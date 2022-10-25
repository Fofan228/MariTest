using FluentValidation;
using Mari.Domain.Entities;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Entities;

public class PlatformValidator : AbstractValidator<Platform>
{
    public PlatformValidator(IValidator<PlatformName> platformNameValidator)
    {
        RuleFor(x => x.Name)
            .SetValidator(platformNameValidator);
    }
}
