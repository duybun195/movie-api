using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_basic.Domain.Entities.Movies;

namespace movie_basic.Infrastructure.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.ConfigurateBase<Movie, int>();

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Title).IsRequired();

        builder.HasOne(s => s.Cover)
        .WithOne()
        .HasForeignKey<Movie>(s => s.MediaId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired(false);
    }
}
