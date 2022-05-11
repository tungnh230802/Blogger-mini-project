using BlogDAL.Models;
using BlogRepository.Interfaces;

namespace BlogRepository
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(BlogContext context) : base(context) { }
    }
}
