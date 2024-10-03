using Microsoft.AspNetCore.Mvc;
using PC_FORUM.Models;
using PC_FORUM.Interfaces;
using System.Security.Claims;


namespace PC_FORUM.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;


        public TopicController(ITopicRepository topicRepository, ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _topicRepository = topicRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title, string content)
        {
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
                Title = title,
                UserId = userId,
                UserName = userName,
                Content = content,
                CreatedAt = DateTime.Now,
            };

            if (ModelState.IsValid)
            {
                _topicRepository.Add(topic); // Ожидание завершения добавления
                return RedirectToAction("Index");
            }
            else
            {
                // Добавление ошибки в модель, если данные не валидны
                ModelState.AddModelError("", "Некорректные данные. Попробуйте еще раз.");
            }

            // Возврат в представление с моделью
            return View(topic);
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

