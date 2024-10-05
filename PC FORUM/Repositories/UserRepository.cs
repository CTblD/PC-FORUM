using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;

namespace PC_FORUM.Repositories
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
        public async Task<AppUser> GetUserByIdAsync(AppUser user)
        {
            return await _userManager.FindByIdAsync(user.Id);
        }

        // Создание пользователя
        public async Task Create(AppUser user)
        {
            await _userManager.CreateAsync(user);
        }

        // Обновление данных пользователя
        public async Task Update(AppUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        // Удаление пользователя
        public async Task Delete(AppUser user)
        {
            user = await _userManager.FindByIdAsync(user.Id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
    }

}
