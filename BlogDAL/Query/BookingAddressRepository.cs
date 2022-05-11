using BlogDAL.Models;
using Microsoft.EntityFrameworkCore;
using SES.HomeServices.Data.Queries;
using SES.HomeServices.Data.Queries.Abstractions;
using SES.HomeServices.Data.Repositories.Abstractions;
using System;

namespace SES.HomeServices.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        private BlogContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        public PostRepository(BlogContext dbContext) : base(dbContext)
        { _context = dbContext; }
        /// <summary>
        /// BuildQuery
        /// </summary>
        /// <returns></returns>
        public IPostQuery BuildQuery()
        {
            return new PostQuery(dbSet.AsQueryable(), _context);
        }
    }
}
