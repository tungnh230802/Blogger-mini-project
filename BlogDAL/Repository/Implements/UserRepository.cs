using BlogDAL.Models;
using BlogRepository.Interfaces;

namespace BlogRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogContext context) : base(context) { }
    }
}
