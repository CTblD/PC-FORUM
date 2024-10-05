using Microsoft.AspNetCore.Mvc.Rendering;

namespace PC_FORUM.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
		public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }


}
