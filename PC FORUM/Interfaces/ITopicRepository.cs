using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAll();
        Task<Topic> GetByIdAsync(int id);
        Task<Topic> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Topic>> GetTopicByTitle(string title);
        bool Add(Topic topic);
        bool Update(Topic topic);
        bool Delete(Topic topic);
        bool Save();
    }
}
