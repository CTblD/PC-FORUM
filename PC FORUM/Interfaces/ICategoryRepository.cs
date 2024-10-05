using PC_FORUM.Data;
using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAll();
		Task<Category> GetById(int id);
	}
}
