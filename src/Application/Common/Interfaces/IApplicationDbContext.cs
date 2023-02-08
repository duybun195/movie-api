using Microsoft.EntityFrameworkCore;
using movie_basic.Domain.Entities.Medias;
using movie_basic.Domain.Entities.Movies;
using movie_basic.Domain.Entities.UserMovies;

namespace movie_basic.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Media> Medias { get; }

    DbSet<Movie> Movies { get; }

    DbSet<UserMovie> UserMovies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
