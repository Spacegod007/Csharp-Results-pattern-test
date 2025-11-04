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

    // This method should be an extension method or implicit conversion to simplify logical operations that happen in the controller for a response.
    private IResult MapErrors(IEnumerable<Error> errors)
    {
        // We could use custom error codes and descriptions to give more detailed error responses and even use ProblemDetails for a more standardized approach.
        // This is demo code to view options and possibilities.

        // For simplicity, we only handle NotFound error here.
        if (errors.Any(error => error.Type == ErrorType.NotFound))
        {
            return Results.NotFound();
        }

        // For other errors, return a generic 400 Bad Request.
        return Results.BadRequest();
    }
}
