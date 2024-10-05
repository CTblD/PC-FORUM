using Microsoft.EntityFrameworkCore;
using PC_FORUM.Data;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;

namespace PC_FORUM.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            return await _context.Topics.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Topic>> GetTopicByCategoryIdAsync(int categoryId)
        {
            return await _context.Topics
                .Where(t => t.CategoryId == categoryId)
                .OrderBy(t => t.CreatedAt) // Сортировка по дате создания
                .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicByTitle(string title)
        {
            return await _context.Topics.Where(c => c.Title.Contains(title)).ToListAsync();
        }

        public async Task AddAsync(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }

        public bool Delete(Topic topic)
        {
            _context.Remove(topic);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Topic topic)
        {
            _context.Update(topic);
            return Save();
        }
    }
}
