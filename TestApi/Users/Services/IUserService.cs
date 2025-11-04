using OneOf;

using TestApi.Users.Errors;

namespace TestApi.Users.Services;

public interface IUserService
{
    Task<OneOf<IEnumerable<User>>> GetAllUsersAsync();
    Task<OneOf<User, UserNotFound>> GetUserByIdAsync(Guid id);
}