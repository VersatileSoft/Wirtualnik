using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.ProductType;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IProductTypeClient
    {
        [Get("")]
        public Task<ApiResponse<List<ProductTypeModel>>> GetAll();

        [Headers("Authorization: Bearer")]
        [Post("")]
        public Task Create([Body] ProductTypeModel model);

        [Headers("Authorization: Bearer")]
        [Put("/{publicId}")]
        public Task Update(string publicId, ProductTypeModel model);

        [Headers("Authorization: Bearer")]
        [Delete("/{publicId}")]
        public Task Delete(string publicId);
    }
}