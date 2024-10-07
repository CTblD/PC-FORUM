namespace PC_FORUM.Models
{
    public class Comment
    {
        public int Id { get; set; } // Уникальный идентификатор комментария
        public string Content { get; set; } // Текст комментария

        public DateTime CreatedAt { get; set; } // Дата создания

        // Связь с родительским комментарием
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        // Список ответов
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
        public int TopicId { get; set; } // Внешний ключ к топику
        public Topic Topic { get; set; } // Навигационное свойство
        public string UserId { get; set; } // Идентификатор автора комментария
        public string UserName { get; set; }
    }
}
