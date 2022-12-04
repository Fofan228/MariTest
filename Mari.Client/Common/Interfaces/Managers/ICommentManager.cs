

using Mari.Contracts.Comments.Responses;

namespace Mari.Client.Common.Interfaces.Managers;

public interface ICommentManager
{
    Task Create(CommentResponse comment, CancellationToken token = default);
    Task<IList<CommentResponse>> GetAllUserComment(Guid releaseId,CancellationToken token = default);
    Task<IList<CommentResponse>> GetAllSystemComment(Guid releaseId,CancellationToken token = default);
    Task UpdateComments(CommentResponse comment,CancellationToken token = default);
    Task DeleteComments(Guid commmentId, CancellationToken token = default);
}
