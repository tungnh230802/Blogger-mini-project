using BlogBLL.ModelRequest;
using BlogBLL.ModelRequest.Post;
using BlogBLL.Services.Interfaces;
using BlogBLL.Utility.BlogException;
using BlogBLL.Utility.Common;
using BlogDAL.Models;
using BlogRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlogBLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;
        private IStorageService _storageService;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork, IStorageService storageService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }
        public async Task Create(Post post)
        {
            if (post == null) throw new ArgumentException(nameof(post));

            try
            {
                post.id = Guid.NewGuid();
                post.createAt = DateTime.Now;
                GetSummaryPost(post);
                GetSlugPost(post);

                await _postRepository.dbSet.AddAsync(post);
                await _unitOfWork.Save();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DbEntityValidationException(ex.Message);
            }
        }


        public async Task<IEnumerable<Post>> GetAll()
        {
            try
            {
                var posts = await _postRepository.dbSet.ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageResult<Post>> GetAllPaging(PostPagingRequest postPagingRequest)
        {
            var query = _postRepository.dbSet.Where(p => p.title.Contains(postPagingRequest.keywork) || p.content.Contains(postPagingRequest.keywork));

            if (postPagingRequest.authorIds.Count > 0)
            {
                query = query.Where(p => postPagingRequest.authorIds.Contains(p.authorId));
            }
            int totalRow = await query.CountAsync();

            var data = await query.Skip((postPagingRequest.PageIndex - 1) * postPagingRequest.PageSize).Take(postPagingRequest.PageSize).ToListAsync();

            var pageResult = new PageResult<Post>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pageResult;
        }

        public async Task<Post> GetById(Guid id)
        {
            try
            {
                var post = await _postRepository.dbSet.FindAsync(id);
                if (post == null) throw new BlogException($"Can't find post: {id}");

                return post;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Post post)
        {
            try
            {
                post.updateAt = DateTime.Now;
                _postRepository.dbSet.Update(post);
                await _unitOfWork.Save();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public async Task Delete(Post post)
        {
            try
            {
                _postRepository.dbSet.Remove(post);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
    }
}
