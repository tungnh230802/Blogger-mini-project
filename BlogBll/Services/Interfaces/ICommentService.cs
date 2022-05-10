using BlogDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogBLL.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAll(int idPost);
        Task<Comment> GetById(int id);
        Task Create(Comment comment);
        Task Update(Comment comment);
        Task Delete(Comment comment);
    }
}
