namespace PC_FORUM.Models
{
    public class Comment
    {
        public int Id { get; set; } // Уникальный идентификатор комментария

        public int TopicId { get; set; } // Внешний ключ к топику
        public Topic Topic { get; set; } // Навигационное свойство
        public string UserId { get; set; } // Идентификатор автора комментария
        public string UserName { get; set; }

        public string Content { get; set; } // Текст комментария

        public DateTime CreatedAt { get; set; } // Дата создания

        ////Реализовать позже
        //public int? ParentCommentId { get; set; } // Для вложенных комментариев (если есть)
        //public Comment ParentComment { get; set; } // Навигационное свойство для родительского комментария
        //public ICollection<Comment> Replies { get; set; } // Ответы на комментарий (если есть)
    }
}
