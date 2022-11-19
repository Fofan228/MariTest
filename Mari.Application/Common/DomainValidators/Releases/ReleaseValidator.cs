using FluentValidation;
using Mari.Domain.Releases;
using Mari.Domain.Releases.Entities;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases;

public class ReleaseValidator : AbstractValidator<Release>
{
    public ReleaseValidator(
        IValidator<ReleaseId> releaseIdValidator,
        IValidator<Platform> platformValidator,
        IValidator<ReleaseVersion> releaseVersionValidator,
        IValidator<ReleaseUpdateDate> releaseUpdateDateValidator,
        IValidator<ReleaseCompleteDate> releaseCompleteDateValidator)
    {
        RuleFor(r => r.Id)
            .SetValidator(releaseIdValidator);


        RuleFor(r => r.Platform)
            .SetValidator(platformValidator);

        RuleFor(r => r.Status)
            .IsInEnum();

        RuleFor(r => r.Version)
            .SetValidator(releaseVersionValidator);

        RuleFor(r => r.UpdateDate)
            .SetValidator(releaseUpdateDateValidator);

        RuleFor(r => r.CompleteDate)
            .SetValidator(releaseCompleteDateValidator);
    }
}
