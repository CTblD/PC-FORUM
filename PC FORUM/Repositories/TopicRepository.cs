using Microsoft.EntityFrameworkCore;
using PC_FORUM.Data;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;

namespace PC_FORUM.Services
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Topic topic)
        {
            _context.Add(topic);
            return Save();
        }

        public bool Delete(Topic topic)
        {
            _context.Remove(topic);
            return Save();
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic> GetByIdAsync(int id)
        {
            return await _context.Topics.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Topic> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Topics.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Topic>> GetTopicByTitle(string title)
        {
            return await _context.Topics.Where(c => c.Title.Contains(title)).ToListAsync();
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
