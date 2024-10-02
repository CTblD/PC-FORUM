using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllTopicAsync();
        Task<Topic> GetTopicByIdAsync(int id);
        Task<IEnumerable<Topic>> GetTopicByTitle(string title);
        bool AddTopic(Topic topic);
        bool UpdateTopic(Topic topic);
        bool DeleteTopic(Topic topic);
        bool SaveTopic();
    }
}
