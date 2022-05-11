using BlogDAL.Models;
using BlogRepository.Interfaces;
using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext context;
        public UnitOfWork(BlogContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }
        public async Task<int> Save()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                var sb = new StringBuilder();
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        sb.AppendLine(string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                throw new Exception(sb.ToString(), dbEx);
            }
        }
    }
}
