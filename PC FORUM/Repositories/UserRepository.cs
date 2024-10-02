using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;

namespace PC_FORUM.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Получение текущего авторизованного пользователя
        public async Task<AppUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        // Получение всех пользователей
        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        // Получение пользователя по ID
        public async Task<AppUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        // Создание пользователя
        public async Task CreateUserAsync(AppUser user)
        {
            await _userManager.CreateAsync(user);
        }

        // Обновление данных пользователя
        public async Task UpdateUserAsync(AppUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        // Удаление пользователя
        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
    }

}
