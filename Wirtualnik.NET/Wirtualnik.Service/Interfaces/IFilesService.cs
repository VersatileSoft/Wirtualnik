using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;

namespace Wirtualnik.Service.Interfaces
{
    public interface IFilesService : IServiceBase
    {
        Task<IEnumerable<Image>> SaveImages(List<IFormFile> images);
        Task<IEnumerable<Image>> GetImages(List<int> images);
        Task<Image> GetImage(int images);
        string GetImageLink(string fileName);
        Task<string> GetImageLink(int imageId);
    }
}