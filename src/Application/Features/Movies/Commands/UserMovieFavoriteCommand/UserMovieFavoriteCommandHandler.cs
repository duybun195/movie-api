using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movie_basic.Application.Common.Exceptions;
using movie_basic.Application.Common.Interfaces;
using movie_basic.Domain.Entities.UserMovies;
using movie_basic.Domain.Enums.Favorites;

namespace movie_basic.Application.Features.Movies;

public class UserMovieFavoriteCommandHandler : ApplicationBaseService<UserMovieFavoriteCommandHandler>, IRequestHandler<UserMovieFavoriteCommand, bool>
{
    private readonly ICurrentUserService _currentUserService;
    public UserMovieFavoriteCommandHandler(ILogger<UserMovieFavoriteCommandHandler> logger,
                                IApplicationDbContext context,
                                IIdentityService identityService,
                                ICurrentUserService currentUserService) : base(logger, context)
    {
        _currentUserService = currentUserService;
    }

    public async Task<bool> Handle(UserMovieFavoriteCommand request, CancellationToken cancellationToken)
    {
        var getMovie = await _context.Movies.FindAsync(new object[] { request.MovieId }, cancellationToken);
        if (getMovie == null)
        {
            throw new NotFoundException("The moview not found.");
        }
        var userMovie = await _context.UserMovies.FirstOrDefaultAsync(s => s.UserId == _currentUserService.UserId && s.MovieId == request.MovieId, cancellationToken);
        if (userMovie == null)
        {
            var newUserMovie = new UserMovie()
            {
                MovieId = request.MovieId,
                UserId = _currentUserService.UserId,
                IsLike = request.IsLike,

                Status = FavoriteStatus.Active
            };
            await _context.UserMovies.AddAsync(newUserMovie, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            if (userMovie.IsLike != request.IsLike)
            {
                userMovie.IsLike = request.IsLike;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        return true;
    }
}