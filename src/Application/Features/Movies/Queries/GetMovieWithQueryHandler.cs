using MediatR;
using Microsoft.EntityFrameworkCore;
using movie_basic.Application.Common.Interfaces;
using movie_basic.Application.Common.Mappings;
using movie_basic.Application.Common.Models;
using movie_basic.Application.Features.Movies.Dtos;
using movie_basic.Domain.Enums.Favorites;

namespace movie_basic.Application.Features.Movies;

public class GetMovieWithQueryHandler : IRequestHandler<GetMovieWithQuery, PaginatedList<MovieDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMovieWithQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<MovieDto>> Handle(GetMovieWithQuery request, CancellationToken cancellationToken)
    {
        var data = await _context.Movies
                        .Include(s => s.Cover)
                        .Include(s => s.UserMovies.Where(s => s.Status == FavoriteStatus.Active))
                        .OrderBy(x => x.Title)
                        .Select(m => new MovieDto(m))
                        .PaginatedListAsync(request.PageNumber, request.PageSize);
        return data;
    }
}
