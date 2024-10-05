using Microsoft.AspNetCore.Mvc;
using PC_FORUM.Models;
using PC_FORUM.Interfaces;
using System.Security.Claims;
using PC_FORUM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace PC_FORUM.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicRepository _topicRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICategoryRepository _categoryRepository;


        public TopicController(ITopicRepository topicRepository,
            ICommentRepository commentRepository,
            ICategoryRepository categoryRepository)
        {
            _topicRepository = topicRepository;
            _commentRepository = commentRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var topics = await _topicRepository.GetTopicByCategoryIdAsync(id);
            return View(topics);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var topic = await _topicRepository.GetTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            // Получите комментарии для данного топика
            topic.Comments = (await _commentRepository.GetCommentsByTopicIdAsync(id))
            .OrderByDescending(c => c.CreatedAt) // Сортировка по дате создания
            .ToList();

            return View(topic);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Получите все категории асинхронно
            var categories = await _categoryRepository.GetAll(); // Предполагается, что метод возвращает Task<IEnumerable<Category>>

            // Преобразуйте результат в SelectListItem
            var categorySelectList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            // Теперь присвойте созданный список вашему представлению
            var model = new CreateTopicVM
            {
                Categories = categorySelectList // Используйте вашу новую переменную
            };

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTopicVM topicVM)
        {
            //if (!ModelState.IsValid)
            //{
                // В случае ошибки валидации повторно загружаем категории
                topicVM.Categories = (await _categoryRepository.GetAll())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

             //   return View(topicVM);
            
            var category = _categoryRepository.GetById(topicVM.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError("", "Выбранная категория недействительна.");
                return View(topicVM);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.Identity.Name;
            // Проверка на наличие идентификатора пользователя
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(); // Возврат 401 Unauthorized, если пользователь не аутентифицирован
            }
            // Создание новой темы
            var topic = new Topic
            {
                Title = topicVM.Title,
                UserId = userId,
                UserName = userName,
                Content = topicVM.Content,
                CreatedAt = DateTime.Now,
                CategoryId = topicVM.CategoryId,
            };
            if (ModelState.ContainsKey("Categories"))
            {
                ModelState.Remove("Categories");
            }
            if (ModelState.IsValid)
            {
                await _topicRepository.AddAsync(topic); // Ожидание завершения добавления
                return RedirectToAction("Index", "Topic");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(topicVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int topicId, string content)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.Identity.Name;

            if (userId != null && userName != null)
            {
                if (string.IsNullOrEmpty(content))
                {
                    ModelState.AddModelError("", "Комментарий не может быть пустым.");
                    return RedirectToAction("Details", new { id = topicId });
                }

                var comment = new Comment
                {
                    TopicId = topicId,
                    UserId = userId,
                    UserName = userName,
                    Content = content,
                    CreatedAt = DateTime.Now
                };

                await _commentRepository.AddCommentAsync(comment);
                return RedirectToAction("Details", new { id = topicId });
            }
            return Unauthorized(); // Если пользователь не найден
        }
    }
}

