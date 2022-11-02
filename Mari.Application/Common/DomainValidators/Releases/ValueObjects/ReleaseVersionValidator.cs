using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;

public class ReleaseVersionValidator : AbstractValidator<ReleaseVersion>
{
    public ReleaseVersionValidator()
    {
        RuleFor(rv => rv.Major)
            .GreaterThanOrEqualTo(ReleaseVersion.MinMajor)
            .LessThanOrEqualTo(ReleaseVersion.MaxMajor);

        RuleFor(rv => rv.Minor)
            .GreaterThanOrEqualTo(ReleaseVersion.MinMinor)
            .LessThanOrEqualTo(ReleaseVersion.MaxMinor);

        RuleFor(rv => rv.Patch)
            .GreaterThanOrEqualTo(ReleaseVersion.MinPatch)
            .LessThanOrEqualTo(ReleaseVersion.MaxPatch);

        RuleFor(rv => rv)
            .Must(rv => rv > ReleaseVersion.MinValue)
            .Must(rv => rv < ReleaseVersion.MaxValue);
    }
}
