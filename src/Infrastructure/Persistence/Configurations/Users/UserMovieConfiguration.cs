using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_basic.Domain.Entities.UserMovies;

namespace movie_basic.Infrastructure.Persistence.Configurations;


public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
{
    public void Configure(EntityTypeBuilder<UserMovie> builder)
    {
        builder.ToTable("UserMovies");
        builder.ConfigurateBase<UserMovie, int>();

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.UserId).IsRequired();
        builder.Property(t => t.MovieId).IsRequired();
        builder.HasIndex(x => new { x.MovieId, x.UserId }).IsUnique();
        builder.Property(t => t.Status).IsRequired();


        builder.HasOne(x => x.Movie)
                .WithMany(x => x.UserMovies)
                .HasForeignKey(x => x.MovieId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
    }
}