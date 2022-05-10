using Microsoft.EntityFrameworkCore;

namespace BlogRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> dbSet { get; set; }
    }
}
