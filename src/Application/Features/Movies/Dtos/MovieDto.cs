using movie_basic.Application.Common.Mappings;
using movie_basic.Domain.Entities.Movies;

namespace movie_basic.Application.Features.Movies.Dtos;

public class MovieDto : IMapFrom<Movie>
{
    public MovieDto() { }

    public string Title { get; set; }
    public string CoverURL { get; set; }
    public int TotalLike { get; set; }

    public MovieDto(Movie data)
    {
        Title = data.Title;
        if (data.Cover != null)
        {
            CoverURL = data.Cover.Path;
        }
        TotalLike = data.UserMovies.Select(s => s.UserId).Distinct().Count();
    }
}
