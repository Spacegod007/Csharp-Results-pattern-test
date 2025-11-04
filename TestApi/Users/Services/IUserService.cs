using Ardalis.Result;

namespace TestApi.Users.Services;

public interface IUserService
{
    Task<Result<IEnumerable<User>>> GetAllUsersAsync();
    Task<Result<User>> GetUserByIdAsync(Guid id);
}