using PC_FORUM.Data;
using PC_FORUM.Models;

namespace PC_FORUM.Interfaces
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetAll();
	}
}
