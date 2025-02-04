using Microsoft.AspNetCore.Http;

namespace CLINICAL.Application.Interface.Services
{
    public interface IFileStorage
    {
        Task<string> SaveFile(string container, IFormFile file);
        Task<string> EditFile(string container, IFormFile file, string route);
    }
}