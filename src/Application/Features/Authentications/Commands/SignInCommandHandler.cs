using MediatR;
using Microsoft.Extensions.Logging;
using movie_basic.Application.Common.Exceptions;
using movie_basic.Application.Common.Interfaces;
using movie_basic.Application.Features.Authentications.Dtos;

namespace movie_basic.Application.Features.Authentications;

public class SignInCommandHandler : ApplicationBaseService<SignInCommandHandler>, IRequestHandler<SignInCommand, SignInResponse>
{
    private readonly IIdentityService _identityService;
    public SignInCommandHandler(ILogger<SignInCommandHandler> logger,
                                IApplicationDbContext context,
                                IIdentityService identityService) : base(logger, context)
    {
        _identityService = identityService;
    }

    public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var response = await _identityService.SignInAsync(request);
        if (response == null)
        {
            throw new NotFoundException("Username or password incorrect!!!");
        }
        return response;
    }
}