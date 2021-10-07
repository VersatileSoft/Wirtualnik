using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Files;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IFilesClient
    {
        [Multipart]
        [Headers("Authorization: Bearer")]
        [Post("/{publicId}")]
        public Task<IApiResponse<List<ImageModel>>> Create(List<StreamPart> images);

        [Headers("Authorization: Bearer")]
        [Get("/{id}")]
        public Task<IApiResponse<ImageModel>> Fetch(int id);

        [Get("/{ids}")]
        public Task<IApiResponse<List<ImageModel>>> FetchMany(List<int> ids);
    }
}