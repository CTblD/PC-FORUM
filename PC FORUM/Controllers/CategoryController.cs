using Microsoft.AspNetCore.Mvc;
using PC_FORUM.Interfaces;

namespace PC_FORUM.Controllers
{
	public class CategoryController : Controller
	{
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()

        {
            var categories = _categoryRepository.GetAll();
            return View(categories);
        }
    }
}
