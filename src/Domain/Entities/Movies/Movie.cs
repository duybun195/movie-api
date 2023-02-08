using movie_basic.Domain.Entities.Medias;
using movie_basic.Domain.Entities.UserMovies;

namespace movie_basic.Domain.Entities.Movies;
public class Movie : BaseAuditableEntity
{
    public string Title { get; set; }
    public int? MediaId { get; set; }

    public virtual Media Cover { get; set; }
    public virtual ICollection<UserMovie> UserMovies { get; set; } = new List<UserMovie>();
}
