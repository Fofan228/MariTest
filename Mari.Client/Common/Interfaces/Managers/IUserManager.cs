using Mari.Contracts.Users.Responce;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IUserManager
{
    Task<IList<UserResponce>> GetAll(CancellationToken token = default);
    Task Update(UserResponce model,CancellationToken token = default);
}
