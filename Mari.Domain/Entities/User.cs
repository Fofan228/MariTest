using Mari.Domain.Common.BaseClasses;
using Mari.Domain.Enums;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class User : EntityBase<int>
{
    // TODO Разбить на домены, добавить комменты, добавить валидацию, EF Core, 
    // TODO Изменить конструкторы, оставив только обязательные поля, неважные проставить default
    private User()
    {
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

    public void ChangeIsActive(bool isActive)
    {
        IsActive = isActive;
    }

    public static User Create(Username username, UserRole role, bool isActive = false) => new User
    {
        Username = username,
        Role = role
    };
}
