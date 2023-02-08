using MediatR;
using Microsoft.Extensions.Logging;
using movie_basic.Application.Common.Exceptions;
using movie_basic.Application.Common.Interfaces;
using movie_basic.Application.Common.Models;
using movie_basic.Domain.Const.Users;

namespace movie_basic.Application.Features.User;

public class AddUserCommandHandler : ApplicationBaseService<AddUserCommandHandler>, IRequestHandler<AddUserCommand, (Result, string)>
{
    private readonly IIdentityService _identityService;
    public AddUserCommandHandler(ILogger<AddUserCommandHandler> logger,
                                IApplicationDbContext context,
                                IIdentityService identityService) : base(logger, context)
    {
        _identityService = identityService;
    }

    public async Task<(Result, string)> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var userExisted = await _identityService.UserExistedAsync(request.UserName, request.Email);
        if (userExisted)
        {
            throw new DomainException("User", "The user already exists.");
        }

        var user = await _identityService.CreateUserAsync(request.UserName, request.Email, request.Password, RoleEnum.User);
        return user;
    }
}
