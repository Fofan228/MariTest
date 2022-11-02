using Mari.Domain.Comments;
using Mari.Domain.Comments.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mari.Infrastructure.Persistence.Configurations;
//TODO доделать
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.OwnsOne(c => c.Id);
        builder.OwnsOne(c => c.Content);
        builder.OwnsOne(c => c.ReleaseId);
        builder.OwnsOne(c => c.UserId);

        builder.Property(c => c.Content)
            .IsRequired()
            .HasMaxLength(CommentContent.MaxLength);

        builder.Property(c => c.ReleaseId)
            .IsRequired();

        builder.Property(c => c.UserId)
            .IsRequired();
    }
}
