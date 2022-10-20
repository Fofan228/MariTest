using Mari.Domain.Common.BaseClasses;
using Mari.Domain.Enums;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class User : EntityBase<int>
{
    // TODO Разбить на домены, добавить комменты, добавить валидацию, EF Core, 
    // TODO Изменить конструкторы, оставив только обязательные поля, неважные проставить default
    public User()
    {
    }

    public User(int id, Username username, UserRole role) : base(id)
    {
        Username = username;
        Role = role;
    }

    public Username Username { get; init; } = null!;
    public UserRole Role { get; init; }
}