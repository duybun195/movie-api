using FluentValidation;

namespace movie_basic.Application.Features.Movies;

public class UserMovieFavoriteCommandValidator : AbstractValidator<UserMovieFavoriteCommand>
{
    public UserMovieFavoriteCommandValidator()
    {

        RuleFor(v => v.MovieId).NotEmpty().GreaterThan(0);

        RuleFor(v => v.IsLike).NotNull();
    }
}
