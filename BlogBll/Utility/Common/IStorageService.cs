using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace BlogBLL.Utility.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
        Task<string> SaveFile(IFormFile file);
    }
}
