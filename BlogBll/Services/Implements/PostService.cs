using BlogBLL.Services.Interfaces;
using BlogDAL.Models;
using BlogRepository;
using BlogRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogBLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
        }
        public async Task Create(Post post)
        {
            post.createAt = DateTime.Now;
            GetSummaryPost(post);
            GetSlugPost(post);

            await _postRepository.dbSet.AddAsync(post);
            await _unitOfWork.Save();
        }

        private static void GetSlugPost(Post post)
        {
            post.slug = post.title.Replace(" ", "-");

            int slugLength = post.slug.Length;

            if (post.slug.LastIndexOf("-") == slugLength)
                post.slug = post.slug.Substring(0, slugLength);
        }

        private static void GetSummaryPost(Post post)
        {
            const int MAX_LENGTH_SUMMARY = 150;
            if (post.content.Length > MAX_LENGTH_SUMMARY)
                post.summary = post.content.Substring(0, MAX_LENGTH_SUMMARY) + "...";
            else
                post.summary = post.content;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var posts = await _postRepository.dbSet.ToListAsync();

            return posts;
        }

        public async Task<Post> GetById(Guid id)
        {
            var post = await _postRepository.dbSet.FindAsync(id);

            return post;
        }

        public async Task Update(Post post)
        {
            post.updateAt = DateTime.Now;
            _postRepository.dbSet.Update(post);
            await _unitOfWork.Save();
        }

        public async Task Delete(Post post)
        {
            _postRepository.dbSet.Remove(post);
            await _unitOfWork.Save();
        }
    }
}
