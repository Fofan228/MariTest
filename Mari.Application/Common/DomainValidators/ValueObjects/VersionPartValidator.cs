using FluentValidation;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators;

public class VersionPartValidator : AbstractValidator<VersionPart>
{
    public VersionPartValidator()
    {
        RuleFor(vp => vp.Value)
            .NotEmpty()
            .GreaterThanOrEqualTo(VersionPart.MinValue);
    }
}