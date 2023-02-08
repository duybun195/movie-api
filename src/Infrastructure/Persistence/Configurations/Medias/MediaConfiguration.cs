using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_basic.Domain.Entities.Medias;

namespace movie_basic.Infrastructure.Persistence.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("Medias");
        builder.ConfigurateBase<Media, int>();

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.OriginalName).IsRequired();
        builder.Property(t => t.Name).IsRequired();
        builder.Property(t => t.ContentType).IsRequired();
        builder.Property(t => t.Type).IsRequired();
        builder.Property(t => t.Status).IsRequired();
    }
}
