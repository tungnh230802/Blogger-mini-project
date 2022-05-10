using BlogDAL.Models;
using BlogRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DbSet<T> dbSet { get; set; } 
        public GenericRepository(BlogContext context)
        {
            dbSet = context.Set<T>();
        }
    }
}
