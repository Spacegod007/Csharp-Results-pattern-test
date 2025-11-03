namespace TestApi.Users.Services;

using Microsoft.AspNetCore.Http;

public interface IUserService
{
    Task<IResult> GetAllUsersAsync();
    Task<IResult> GetUserByIdAsync(Guid id);
}