using Mari.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mari.Infrastructure.Persistence.Configurations;
//TODO Доделать
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(u => u.Username);
        builder.OwnsOne(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired();

        builder.Property(u => u.IsActive)
            .IsRequired();

        builder.Property(u => u.Role)
            .IsRequired();
    }
}
