using BlogBLL.Services.Interfaces;
using BlogDAL.Models;
using BlogRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task Create(Comment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));

            try
            {
                comment.id = Guid.NewGuid();
                comment.createAt = DateTime.Now;

                await _commentRepository.dbSet.AddAsync(comment);
                await _unitOfWork.Save();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DbEntityValidationException(ex.Message);
            }
        }

        public async Task<IEnumerable<Comment>> GetAll(Guid idPost)
        {
            try
            {
                var comments = await _commentRepository.dbSet.Where(c => c.postId == idPost).ToListAsync();

                return comments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Comment> GetById(Guid id)
        {
            try
            {
                var comment = await _commentRepository.dbSet.FindAsync(id);
                if (comment == null) throw new Exception($"Can't get comment {id}");

                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Comment comment)
        {
            try
            {
                comment.updateAt = DateTime.Now;

                _commentRepository.dbSet.Update(comment);
                await _unitOfWork.Save();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task Delete(Comment comment)
        {
            try
            {
                _commentRepository.dbSet.Remove(comment);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
