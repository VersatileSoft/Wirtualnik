using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IProductClient
    {
        [Get("")]
        public Task<ApiResponse<Pagination<ListItemModel>>> Search([Query] Pager pager, [Query] string typePublicId, [Query] Dictionary<string, string> filter);

        [Get("/{publicId}")]
        public Task<ApiResponse<DetailsModel>> Fetch(string publicId);

        [Headers("Authorization: Bearer")]
        [Post("")]
        public Task Create([Body] CreateModel model);

        [Headers("Authorization: Bearer")]
        [Put("/{publicId}")]
        public Task Update(string publicId, CreateModel model);

        [Headers("Authorization: Bearer")]
        [Delete("/{publicId}")]
        public Task Delete(string publicId);

        [Headers("Authorization: Bearer")]
        [Post("/type")]
        public Task CreateProductType(ProductTypeModel model);

        [Get("/type")]
        [Headers("Authorization: Bearer")]
        public Task<ApiResponse<List<ProductTypeModel>>> GetAllProductTypes();
    }
}