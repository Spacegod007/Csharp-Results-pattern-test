using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using TestApi.Users.Services;

namespace TestApi.Users.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task GetAll()
    {
        var result = await _userService.GetAllUsersAsync();

        // Build an IResult and execute it directly on the HttpContext to send the response
        IResult response = Results.Ok(result.AsT0);
        await response.ExecuteAsync(HttpContext);
    }

    [HttpGet("{id:guid}")]
    public async Task GetById(Guid id)
    {
        var result = await _userService.GetUserByIdAsync(id);

        IResult response;
        if (result.IsT0)
        {
            var user = result.AsT0;
            response = Results.Ok(user);
        }
        else
        {
            var notFound = result.AsT1;
            response = Results.NotFound(new { Message = $"User with id {notFound.Id} not found" });
        }

        await response.ExecuteAsync(HttpContext);
    }
}
