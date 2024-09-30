namespace PC_FORUM.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        //// Связь с пользователем (автором)
        //public string UserId { get; set; }
        //public User Author { get; set; }

        // Связь с комментариями
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

}
