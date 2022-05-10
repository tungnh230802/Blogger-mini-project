using System.Threading.Tasks;

namespace BlogRepository.Interfaces
{
    public interface IUnitOfWork 
    {
        Task<int> Save();
    }
}
