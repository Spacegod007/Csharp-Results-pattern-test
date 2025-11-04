using ErrorOr;

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

        var httpResult = result.Match(
            users => Results.Ok(users),
            errors => MapErrors(errors));

        await httpResult.ExecuteAsync(HttpContext);
    }

    [HttpGet("{id:guid}")]
    public async Task GetById(Guid id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        
        var httpResult = result.Match(
            user => Results.Ok(user),
            errors => MapErrors(errors));

        await httpResult.ExecuteAsync(HttpContext);
    }

    private IResult MapErrors(IEnumerable<Error> errors)
    {
        // For simplicity, we only handle NotFound error here.
        if (errors.Any(error => error.Type == ErrorType.NotFound))
        {
            return Results.NotFound();
        }

        // For other errors, return a generic 400 Bad Request.
        return Results.BadRequest();
    }
}
