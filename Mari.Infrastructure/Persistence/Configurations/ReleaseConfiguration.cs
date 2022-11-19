using Mari.Domain.Releases;
using Mari.Domain.Releases.ValueObjects;
using Mari.Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mari.Infrastructure.Persistence.Configurations;

public class ReleaseConfiguration : IEntityTypeConfiguration<Release>
{
    public void Configure(EntityTypeBuilder<Release> builder)
    {
        builder.Property(r => r.Id)
            .IsValueObjectWrapper<Guid, ReleaseId>();

        builder.Property(r => r.CompleteDate)
            .IsValueObjectWrapper<DateTime, ReleaseCompleteDate>()
            .IsRequired();

        builder.Property(r => r.UpdateDate)
            .IsValueObjectWrapper<DateTime, ReleaseUpdateDate>()
            .IsRequired();

        builder.Property(r => r.Status)
            .IsRequired();

        builder.OwnsOne(r => r.Version);

        builder.HasOne(r => r.Platform)
            .WithMany();
    }
}
