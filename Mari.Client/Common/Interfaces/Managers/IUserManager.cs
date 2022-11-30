using Mari.Contracts.Users.Responce;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IUserManager
{
    Task<IEnumerable<UserResponce>> GetAll(CancellationToken token);
    Task Update(UserResponce model,CancellationToken token);
}
