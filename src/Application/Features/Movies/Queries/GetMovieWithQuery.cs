using MediatR;
using movie_basic.Application.Common.Models;
using movie_basic.Application.Features.Movies.Dtos;

namespace movie_basic.Application.Features.Movies;


public record GetMovieWithQuery : IRequest<PaginatedList<MovieDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
