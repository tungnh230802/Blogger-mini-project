using BlogDAL.Models;
using BlogRepository.Interfaces;

namespace BlogRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context) { }
    }
}
