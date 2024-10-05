using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using PC_FORUM.Models;

namespace PC_FORUM.ViewModels
{
    public class CreateTopicVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        // Выбранная категория
        //[Required(ErrorMessage = "The Categories field is required.")]
        public int CategoryId { get; set; }
        // Список категорий для выбора
        [BindNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
