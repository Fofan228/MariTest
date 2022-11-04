using Mari.Domain.Common.Models;
using Mari.Domain.Users.Enums;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Domain.Users;

public class User : AggregateRoot<UserId>
{
    public static User Create(Username username, UserRole role = UserRole.Guest, UserId? id = null)
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
        IsActive = false;
    }

    public Username Username { get; private set; } = null!;
    public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }

    public void ChangeUsername(Username username)
    {
        Username = username;
    }

    public void ChangeRole(UserRole role)
    {
        Role = role;
    }

    public void BlockUser()
    {
        IsActive = false;
    }

    public void UnblockUser()
    {
        IsActive = true;
    }
}
