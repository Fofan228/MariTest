

using Mari.Contracts.Users.Response;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IUserManager
{
    Task<IList<UserResponse>> GetAll(CancellationToken token = default);
    Task Update(UserResponse model,CancellationToken token = default);
}
