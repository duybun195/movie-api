using movie_basic.Domain.Entities.Movies;
using movie_basic.Domain.Enums.Favorites;

namespace movie_basic.Domain.Entities.UserMovies;

public class UserMovie : BaseAuditableEntity
{
    public string UserId { get; set; }
    public int MovieId { get; set; }
    public bool IsLike { get; set; }
    public FavoriteStatus Status { get; set; }


    public virtual Movie Movie { get; set; }
}

