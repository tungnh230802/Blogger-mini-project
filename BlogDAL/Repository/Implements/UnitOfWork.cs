using BlogDAL.Models;
using BlogRepository.Interfaces;
using System.Threading.Tasks;

namespace BlogRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext context;
        public UnitOfWork(BlogContext context)
        {
            this.context = context;
        }
        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}
