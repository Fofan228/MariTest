using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Releases.Commands.DeleteRelease;

public class DeleteReleaseValidator : AbstractValidator<DeleteReleaseCommand>
{
    public DeleteReleaseValidator(IValidator<ReleaseId> releaseIdValidator)
    {
        RuleFor(x => x.Id)
            .SetValidator(releaseIdValidator);
    }
}
