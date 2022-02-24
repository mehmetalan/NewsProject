using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int NewsId { get; set; }

    }
}