using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetCurrentUserAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string userId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string userId);
    }
}
