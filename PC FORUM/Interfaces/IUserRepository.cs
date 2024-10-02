using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetCurrentUserAsync();
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(string userId);
        Task CreateUserAsync(AppUser userId);
        Task UpdateUserAsync(AppUser userId);
        Task DeleteUserAsync(string userId);
    }
}
