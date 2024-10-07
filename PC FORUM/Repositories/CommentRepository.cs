using Microsoft.EntityFrameworkCore;
using PC_FORUM.Data;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;

namespace PC_FORUM.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByTopicIdAsync(int topicId)
        {
            return await _context.Comments
                .Where(c => c.TopicId == topicId && c.ParentCommentId == null) // Главные комментарии
                .Include(c => c.Replies) // Подгрузить ответы
                .ToListAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task Add(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
