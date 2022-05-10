using BlogDAL.Models;
using BlogRepository.Interfaces;

namespace BlogRepository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context) { }
    }
}
