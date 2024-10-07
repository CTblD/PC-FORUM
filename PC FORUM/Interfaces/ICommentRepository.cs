using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByTopicIdAsync(int topicId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task Add(Comment comment);
        Task Update(Comment comment);
        Task Delete(int commentId);
    }
}
