using MediatR;

namespace movie_basic.Application.Features.Movies;

public class UserMovieFavoriteCommand : IRequest<bool>
{
    public int MovieId { get; set; }
    public bool IsLike { get; set; }
}
