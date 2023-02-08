using Microsoft.AspNetCore.Mvc;
using movie_basic.Application.Common.Models;
using movie_basic.Application.Features.User;

namespace movie_basic.WebUI.Controllers;

public class UserController : ApiControllerBase
{
    [HttpPost]
    public async Task<(Result, string)> Create([FromBody] AddUserCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }
}
