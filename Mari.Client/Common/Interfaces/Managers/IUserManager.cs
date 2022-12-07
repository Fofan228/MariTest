namespace Mari.Client.Common.Interfaces.Managers;

public interface IUserManager
{
    Task<IList<object>> GetAll(CancellationToken token = default);
    Task Update(object model, CancellationToken token = default);
}
