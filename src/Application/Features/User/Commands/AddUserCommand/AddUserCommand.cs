using MediatR;
using movie_basic.Application.Common.Models;

namespace movie_basic.Application.Features.User;
public class AddUserCommand : IRequest<(Result, string)>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
