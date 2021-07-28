using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Service.Interfaces.Base;

namespace Wirtualnik.Service.Interfaces
{
    public interface IFilesService : IServiceBase
    {
        Task SaveImages(List<IFormFile> images, string publicId);
    }
}
