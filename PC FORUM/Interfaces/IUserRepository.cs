using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetCurrentUserAsync();
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(AppUser user);
        Task Create(AppUser userId);
        Task Update(AppUser userId);
        Task Delete(AppUser userId);
    }
}
