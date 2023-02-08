using Microsoft.AspNetCore.Mvc;
using movie_basic.Application.Features.Authentications;
using movie_basic.Application.Features.Authentications.Dtos;

namespace movie_basic.WebUI.Controllers;


public class AuthenController : ApiControllerBase
{
    [HttpPost]
    [Route("sign-in")]
    public async Task<ActionResult<SignInResponse>> SignIn([FromBody] SignInCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }
}
