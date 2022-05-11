using BlogDAL.Models;
using Microsoft.EntityFrameworkCore;
using SES.HomeServices.Data.Repositories.Abstractions;

namespace SES.HomeServices.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbSet<TEntity> dbSet { get; set; }

        public RepositoryBase(BlogContext context)
        {
            dbSet = context.Set<TEntity>();
        }
    }
}