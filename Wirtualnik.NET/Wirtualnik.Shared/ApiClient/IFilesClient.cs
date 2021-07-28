using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IFilesClient
    {
        [Multipart]
        [Headers("Authorization: Bearer")]
        [Post("/{publicId}")]
        public Task Create(string publicId, List<StreamPart> images);
    }
}
