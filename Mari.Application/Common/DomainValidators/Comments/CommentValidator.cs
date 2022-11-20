using System.Data;
using FluentValidation;
using Mari.Application.Common.Interfaces.Persistence;
using Mari.Domain.Comments;
using Mari.Domain.Comments.ValueObjects;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Comments;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator(
        IValidator<CommentId> commentIdValidator,
        IValidator<UserId> userIdValidator,
        IValidator<CommentContent> contentValidator,
        IValidator<CommentCreateDate> createDateValidator,
        IUserRepository userRepository,
        ICommentRepository commentRepository)
    {
        RuleFor(c => c.Id)
            .SetValidator(commentIdValidator)
            .MustAsync(async (commentId, token) => await commentRepository.Exists(commentId, token));

        RuleFor(c => c.UserId)
            .SetValidator(userIdValidator)
            .MustAsync(async (userId, token) => await userRepository.Exists(userId, token));

        RuleFor(c => c.Content)
            .SetValidator(contentValidator);

        RuleFor(c => c.CreateDate)
            .SetValidator(createDateValidator);
    }
}
