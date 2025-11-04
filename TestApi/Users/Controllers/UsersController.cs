using Ardalis.Result.AspNetCore;

using Microsoft.AspNetCore.Mvc;

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

        await result.ToMinimalApiResult()
            .ExecuteAsync(HttpContext);

        // Alternatively when returning ActionResult<T>
        //return await result.ToActionResult(this);
    }

    [HttpGet("{id:guid}")]
    public async Task GetById(Guid id)
    {
        var result = await _userService.GetUserByIdAsync(id);

        await result.ToMinimalApiResult()
            .ExecuteAsync(HttpContext);

        // Alternatively when returning ActionResult<T>
        //return await result.ToActionResult(this);
    }
}
