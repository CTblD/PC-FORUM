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
        public bool AddTopic(Topic topic)
        {
            _context.Add(topic);
            return SaveTopic();
        }

        public bool DeleteTopic(Topic topic)
        {
            _context.Remove(topic);
            return SaveTopic();
        }

        public async Task<IEnumerable<Topic>> GetAllTopicAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            return await _context.Topics.FirstOrDefaultAsync(i => i.Id == id);
        }
        //public async Task<Topic> GetByIdAsyncNoTracking(int id)
        //{
        //    return await _context.Topics.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        //}

        public async Task<IEnumerable<Topic>> GetTopicByTitle(string title)
        {
            return await _context.Topics.Where(c => c.Title.Contains(title)).ToListAsync();
        }
        public async Task CreateTopicAsync(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }
        public bool SaveTopic()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTopic(Topic topic)
        {
            _context.Update(topic);
            return SaveTopic();
        }
    }
}
