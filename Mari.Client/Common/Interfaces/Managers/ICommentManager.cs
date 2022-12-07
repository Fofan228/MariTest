namespace Mari.Client.Common.Interfaces.Managers;

public interface ICommentManager
{
    Task Create(object comment, CancellationToken token = default);
    Task<IList<object>> GetAllUserComment(Guid releaseId, CancellationToken token = default);
    Task<IList<object>> GetAllSystemComment(Guid releaseId, CancellationToken token = default);
    Task UpdateComments(object comment, CancellationToken token = default);
    Task DeleteComments(Guid commmentId, CancellationToken token = default);
}
