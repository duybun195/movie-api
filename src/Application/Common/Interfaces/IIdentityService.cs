using movie_basic.Application.Common.Models;
using movie_basic.Application.Features.Authentications;
using movie_basic.Application.Features.Authentications.Dtos;

namespace movie_basic.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<bool> UserExistedAsync(string? userName = null, string? email = null);

    Task<string> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string email, string password, string role);

    Task<Result> DeleteUserAsync(string userId);

    Task<SignInResponse> SignInAsync(SignInCommand request);
}
