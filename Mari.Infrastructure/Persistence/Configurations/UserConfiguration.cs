using Mari.Domain.Users;
using Mari.Domain.Users.ValueObjects;
using Mari.Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mari.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id)
            .IsValueObjectWrapper<int, UserId>();

        builder.Property(u => u.Username)
            .IsValueObjectWrapper<string, Username>()
            .IsRequired()
            .HasMaxLength(Username.MaxLength);

        builder.Property(u => u.IsActive)
            .IsRequired();

        builder.Property(u => u.Role)
            .IsRequired();
    }
}
