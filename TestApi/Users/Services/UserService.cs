using OneOf;

using TestApi.Users.Errors;

namespace TestApi.Users.Services;

public class UserService : IUserService
{
    public static Guid User1 { get; } = Guid.Parse("e8e35779-65b9-48bc-a41d-470a4b326e89");
    public static Guid User2 { get; } = Guid.Parse("eefd8d7a-8ca3-4905-adcd-a6648708cf69");
    public static Guid User3 { get; } = Guid.Parse("150a28a3-3534-4b9a-81eb-1792182f0f67");

    private List<User> _users = new()
    {
        new() { Id = User1, Name = "Alice", Email = "alice@example.com" },
        new() { Id = User2, Name = "Bob", Email = "bob@example.com" },
        new() { Id = User3, Name = "Charlie", Email = "charlie@example.com" },
    };

    public UserService()
    {
    }

    public async Task<OneOf<IEnumerable<User>>> GetAllUsersAsync()
    {
        // Simulate async operation to preven compiler warning
        await Task.CompletedTask;

        return _users;
    }

    public async Task<OneOf<User, UserNotFound>> GetUserByIdAsync(Guid id)
    {
        // Simulate async operation to preven compiler warning
        await Task.CompletedTask;

        var user = _users.FirstOrDefault(u => u.Id == id);

        if (user is null)
        {
            var notFound = new UserNotFound(id);
            return notFound;
        }

        return user;
    }
}
