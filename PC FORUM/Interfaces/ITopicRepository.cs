using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAll();
        Task<Topic> GetTopicByIdAsync(int id);
        Task<IEnumerable<Topic>> GetTopicByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Topic>> GetTopicByTitle(string title);
        Task AddAsync(Topic topic);
        bool Update(Topic topic);
        bool Delete(Topic topic);
        bool Save();
    }
}
