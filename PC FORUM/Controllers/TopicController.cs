using Microsoft.AspNetCore.Mvc;
using PC_FORUM.Models; // Убедитесь, что у вас есть это пространство имен
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PC_FORUM.Interfaces;
using PC_FORUM.ViewModels;

namespace PC_FORUM.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicRepository _topicRepository;

        public TopicController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Topic> topic = await _topicRepository.GetAll();
            return View(topic);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            Topic topic = await _topicRepository.GetByIdAsync(id);
            return View(topic);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTopicVM topicVM)
        {
            if (ModelState.IsValid)
            {
                var topic = new Topic
                {
                    Title = topicVM.Title,
                    Content = topicVM.Content,
                    CreatedAt = topicVM.CreatedAt,
                };
                _topicRepository.Add(topic);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Фото не загузилось");
            }
            return View(topicVM);
        }
    }
    }

