using FluentValidation;
using Mari.Domain.Comments;

namespace Mari.Application.Common.DomainValidators.Comments;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
