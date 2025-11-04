using ErrorOr;

namespace TestApi.Users.Services;

public interface IUserService
{
    Task<ErrorOr<IEnumerable<User>>> GetAllUsersAsync();
    Task<ErrorOr<User>> GetUserByIdAsync(Guid id);
}