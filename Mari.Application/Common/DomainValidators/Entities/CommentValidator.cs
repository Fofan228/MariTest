using FluentValidation;
using Mari.Domain.Entities;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Entities;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator(IValidator<CommentContent> commentTextValidator)
    {
        //TODO Дописать после репозиториев
        RuleFor(x => x.Content)
            .NotEmpty()
            .SetValidator(commentTextValidator);
    }
}
