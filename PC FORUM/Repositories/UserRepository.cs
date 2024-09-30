using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;

namespace PC_FORUM.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Получение текущего авторизованного пользователя
        public async Task<User> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        // Получение всех пользователей
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        // Получение пользователя по ID
        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        // Создание пользователя
        public async Task CreateUserAsync(User user)
        {
            await _userManager.CreateAsync(user);
        }

        // Обновление данных пользователя
        public async Task UpdateUserAsync(User user)
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
