using Microsoft.AspNetCore.Identity;

namespace PC_FORUM.Models
{
    public class AppUser : IdentityUser
    {
        // Дополнительные поля для пользователя
        public ICollection<Comment> Comments { get; set; }
    }
}
