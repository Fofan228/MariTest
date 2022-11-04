using ErrorOr;
using Mari.Domain.Users.ValueObjects;
using MediatR;

namespace Mari.Application.Users.Queries.Exists;

public class UserExistsQuery : IRequest<ErrorOr<bool>>
{
    public UserExistsQuery(int userId)
    {
        UserId = UserId.Create(userId);
    }

    public UserId UserId { get; init; }
}
