using BlogDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogBLL.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(int id);
        Task Create(Post post);
        Task Update(Post post);
        Task Delete(Post post);
    }
}
