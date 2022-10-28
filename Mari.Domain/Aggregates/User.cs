using Mari.Domain.Common.Models;
using Mari.Domain.Enums;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class User : AggregateRoot<int>
{
    public static User Create(Username username, UserRole role)
    {
        return new User(
            id: default,
            name: username,
            role: role
        );
    }

    private User() : base(default)
    {
    }

    private User(int id, Username name, UserRole role) : base(id)
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
