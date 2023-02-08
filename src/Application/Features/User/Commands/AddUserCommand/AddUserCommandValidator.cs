using FluentValidation;
using movie_basic.Application.Common.Extentions;
using movie_basic.Domain.Const;

namespace movie_basic.Application.Features.User;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        #region fields
        var password = "Password";
        var email = "Email";
        var userName = "UserName";
        #endregion


        #region message
        var minimumLength = "{0} must not be less than {1} characters.";
        var capitalLetters = "{0} must contain one or more capital letters.";
        var lowercaseLetters = "{0} must contain one or more lowercase letters";
        var containDigits = "{0} must contain one or more digits.";
        var noSpace = "{0} must not contain the following characters £ # “” or spaces";
        var wordWrong = "{0} contains a word that is not allowed.";
        var notValid = "{0} not valid.";
        #endregion

        RuleFor(v => v.UserName).NotEmpty().When(s => string.IsNullOrEmpty(s.Email))
                                .Matches(CommonRegex.NoSpace).WithMessage(noSpace.TryFormat(userName));

        RuleFor(request => request.Password).NotEmpty()
            .MinimumLength(8).WithMessage(string.Format(minimumLength, password, 8))
            .Matches(CommonRegex.CapitalLetters).WithMessage(capitalLetters.TryFormat(password))
            .Matches(CommonRegex.LowercaseLetters).WithMessage(lowercaseLetters.TryFormat(password))
            .Matches(CommonRegex.ContainDigits).WithMessage(containDigits.TryFormat(password))
            .Matches(CommonRegex.NoSpace).WithMessage(noSpace.TryFormat(password))
        .WithMessage(wordWrong.TryFormat(password));

        RuleFor(v => v.Email).NotEmpty().When(s => string.IsNullOrEmpty(s.UserName))
                            .EmailAddress().WithMessage(string.Format(notValid, email)).When(v => string.IsNullOrEmpty(v.UserName));
    }
}
