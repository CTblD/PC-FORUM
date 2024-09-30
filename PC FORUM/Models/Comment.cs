namespace PC_FORUM.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Связь с пользователем (автором)
        public string UserId { get; set; }
        public User Author { get; set; }

        // Связь с темой
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
