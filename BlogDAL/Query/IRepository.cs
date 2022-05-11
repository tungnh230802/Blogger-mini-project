using Microsoft.EntityFrameworkCore;

namespace SES.HomeServices.Data.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> dbSet { get; set; }
    }
}