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
        [Post("")]
        public Task<ApiResponse<List<ImageModel>>> Create(List<StreamPart> images);

        [Headers("Authorization: Bearer")]
        [Get("/{id}")]
        public Task<ApiResponse<ImageModel>> Fetch(int id);

        [Get("/{ids}")]
        public Task<ApiResponse<List<ImageModel>>> FetchMany(List<int> ids);
    }
}