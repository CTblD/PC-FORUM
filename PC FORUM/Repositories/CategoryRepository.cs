using PC_FORUM.Data;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;

namespace PC_FORUM.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList(); // Возвращаем все категории
        }
    }
}
