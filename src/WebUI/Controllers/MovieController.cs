using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movie_basic.Application.Common.Models;
using movie_basic.Application.Features.Movies;
using movie_basic.Application.Features.Movies.Dtos;

namespace movie_basic.WebUI.Controllers;


public class MovieController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<MovieDto>>> GetAllMovie([FromQuery] GetMovieWithQuery query)
    {
        return await Mediator.Send(query);
    }


    [Authorize]
    [HttpPost]
    [Route("action")]
    public async Task<ActionResult<bool>> UserActionMovie([FromBody] UserMovieFavoriteCommand query)
    {
        return await Mediator.Send(query);
    }
}