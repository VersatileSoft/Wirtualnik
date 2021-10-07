using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Category;

namespace Wirtualnik.Shared.ApiClient
{
    public interface ICategoryClient
    {
        [Get("")]
        public Task<ApiResponse<List<CategoryModel>>> GetAll();

        [Headers("Authorization: Bearer")]
        [Post("")]
        public Task Create([Body] CategoryModel model);

        [Headers("Authorization: Bearer")]
        [Put("/{publicId}")]
        public Task Update(string publicId, CategoryModel model);

        [Headers("Authorization: Bearer")]
        [Delete("/{publicId}")]
        public Task Delete(string publicId);
    }
}