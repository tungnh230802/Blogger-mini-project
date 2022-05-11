using BlogDAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogBLL.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAll(Guid idPost);
        Task<Comment> GetById(Guid id);
        Task Create(Comment comment);
        Task Update(Comment comment);
        Task Delete(Comment comment);
    }
}
