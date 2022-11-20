using FluentValidation;
using Mari.Application.Common.Interfaces.Persistence;
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
        IValidator<ReleaseCompleteDate> releaseCompleteDateValidator,
        IValidator<ReleaseDescription> releaseDescriptionValidator,
        IValidator<Issue> releaseMainIssueValidator,
        IReleaseRepository releaseRepository)
    {
        RuleFor(r => r.Id)
            .SetValidator(releaseIdValidator)
            .MustAsync(async (releaseId, token) => await releaseRepository.Exists(releaseId, token));

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

        RuleFor(r => r.Description)
            .SetValidator(releaseDescriptionValidator);

        RuleFor(r => r.MainIssue)
            .SetValidator(releaseMainIssueValidator);
    }
}
