using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Releases.Commands.CreateRelease;

public class CreateReleaseCommandValidator : AbstractValidator<CreateReleaseCommand>
{
    public CreateReleaseCommandValidator(
        IValidator<Issue> issueValidator,
        IValidator<ReleaseCompleteDate> releaseCompleteDateValidator,
        IValidator<PlatformName> platformNameValidator,
        IValidator<ReleaseVersion> releaseVersionValidator,
        IValidator<ReleaseDescription> releaseDescriptionValidator)
    {
        RuleFor(x => x.MainIssue)
            .SetValidator(issueValidator);
        RuleFor(x => x.CompleteDate)
            .SetValidator(releaseCompleteDateValidator);
        RuleFor(x => x.PlatformName)
            .SetValidator(platformNameValidator);
        RuleFor(x => x.Version)
            .SetValidator(releaseVersionValidator);
        RuleFor(x => x.Description)
            .SetValidator(releaseDescriptionValidator);
    }
}
