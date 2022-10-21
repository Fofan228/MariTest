using FluentValidation;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.ValueObjects;

public class ReleaseVersionValidator : AbstractValidator<ReleaseVersion>
{
    public ReleaseVersionValidator(IValidator<VersionPart> versionPartValidator)
    {
        RuleFor(rv => rv)
            .Must(rv => rv > ReleaseVersion.MinValue);
        RuleFor(rv => rv.FirstPart)
            .SetValidator(versionPartValidator);
        RuleFor(rv => rv.SecondPart)
            .SetValidator(versionPartValidator);
        RuleFor(rv => rv.ThirdPart)
            .SetValidator(versionPartValidator);
    }
}