using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;

public class PlatformIdValidator : AbstractValidator<PlatformId>
{
    public PlatformIdValidator()
    {
        RuleFor(pi => pi.Value)
            .NotEmpty();
    }
}
