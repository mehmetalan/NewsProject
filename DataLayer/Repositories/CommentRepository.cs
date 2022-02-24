using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CommentRepository
    {
        NewsDbContext _ctx;
        public CommentRepository(NewsDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Comment> GetCommentsByUserId(int userId)
        {
            return _ctx.Comments.Where(c => c.UserId == userId).ToList();
        }

        public Comment GetCommentByCommentId(int commentId)
        {
            return _ctx.Comments.FirstOrDefault(c => c.CommentId == commentId);
        }

        public List<Comment> GetCommentsByNewsId(int newsId)
        {
            return _ctx.Comments.Where(c => c.NewsId == newsId).ToList();
        }

        public void AddComment(Comment comment)
        {
            _ctx.Comments.Add(comment);
            _ctx.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            Comment comment = GetCommentByCommentId(id);
            _ctx.Comments.Remove(comment);
            _ctx.SaveChanges();
        }
    }
}
