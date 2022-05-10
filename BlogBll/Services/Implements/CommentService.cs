using BlogBLL.Services.Interfaces;
using BlogDAL.Models;
using BlogRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Comment comment)
        {
            comment.createAt = DateTime.Now;

            await _commentRepository.dbSet.AddAsync(comment);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Comment>> GetAll(int idPost)
        {
            var comments = await _commentRepository.dbSet.Where(c=>c.postId == idPost).ToListAsync();
            return comments;
        }

        public async Task<Comment> GetById(int id)
        {
            var comment = await _commentRepository.dbSet.FindAsync(id);

            return comment;
        }

        public async Task Update(Comment comment)
        {
            comment.updateAt = DateTime.Now;

            _commentRepository.dbSet.Update(comment);
            await _unitOfWork.Save();
        }

        public async Task Delete(Comment comment)
        {
            _commentRepository.dbSet.Remove(comment);
            await _unitOfWork.Save();
        }
    }
}
