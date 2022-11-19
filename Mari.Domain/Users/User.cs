using ErrorOr;
using Mari.Domain.Common.Models;
using Mari.Domain.Users.Enums;
using Mari.Domain.Users.ValueObjects;
using Mari.Domain.Common.Errors;

namespace Mari.Domain.Users;

public class User : AggregateRoot<UserId>
{
    public static ErrorOr<User> Create(Username username, UserRole role = UserRole.Guest, UserId? id = null)
    {
        return new User(
            id: id ?? UserId.Default,
            name: username,
            role: role
        );
    }

    private User() : base(default!)
    {
    }

    private User(UserId id, Username name, UserRole role) : base(id)
    {
        Username = name;
        Role = role;
        IsActive = true;
    }

    public Username Username { get; private set; } = null!;
    public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }

    public ErrorOr<Updated> ChangeUsername(Username username)
    {
        if (!IsActive) return Errors.User.UserIsBlocked;
        Username = username;
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangeRole(UserRole role)
    {
        //TODO Можно ли изменить роль релиз менеджера?
        if (!IsActive) return Errors.User.UserIsBlocked;
        Role = role;
        return Result.Updated;
    }

    public ErrorOr<Success> BlockUser()
    {
        //TODO Можно ли заблокировать релиз менеджера?
        if (!IsActive) return Errors.User.UserIsBlocked;
        IsActive = false;
        return Result.Success;
    }

    public ErrorOr<Success> UnblockUser()
    {
        IsActive = true;
        return Result.Success;
    }
}
