using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Releases.Commands.CreateReleaseFromDraft;

internal class CreateReleaseFromDraftCommandValidator : AbstractValidator<CreateReleaseFromDraftCommand>
{
    public CreateReleaseFromDraftCommandValidator(
        IValidator<ReleaseId> releaseIdValidator)
    {
        RuleFor(x => x.ReleaseId)
            .SetValidator(releaseIdValidator);
    }
}
