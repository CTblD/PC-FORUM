using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC_FORUM.Models;

namespace PC_FORUM.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Topic) // Предполагается, что у вас есть навигационное свойство Topic в Comment
                .WithMany(t => t.Comments) // Предполагается, что у вас есть коллекция Comments в Topic
                .HasForeignKey(c => c.TopicId) // Замените на ваш фактический идентификатор
                .OnDelete(DeleteBehavior.Restrict); // Измените поведение на NO ACTION

            base.OnModelCreating(modelBuilder);
        }
    }
}
