using FluentValidation;
using Mari.Domain.Releases.Entities;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.Entities;

public class PlatformValidator : AbstractValidator<Platform>
{
    public PlatformValidator(
        IValidator<PlatformName> platformNameValidator,
        IValidator<PlatformId> platformIdValidator)
    {
        RuleFor(p => p.Id)
            .SetValidator(platformIdValidator);

        RuleFor(p => p.Name)
            .SetValidator(platformNameValidator);
    }
}
