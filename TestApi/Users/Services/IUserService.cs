namespace TestApi.Users.Services;

public interface IUserService
{
    Task<IResult> GetAllUsersAsync();
    Task<IResult> GetUserByIdAsync(Guid id);
}