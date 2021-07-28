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
        public Task<Pagination<ListItemModel>> Search([Query] Pager pager, [Query] Dictionary<string, string> filter);

        [Get("/{publicId}")]
        public Task<DetailsModel> Fetch(string publicId);

        [Headers("Authorization: Bearer")]
        [Post("")]
        public Task Create(CreateModel model);

        [Headers("Authorization: Bearer")]
        [Put("/{publicId}")]
        public Task Update(string publicId, CreateModel model);

        [Headers("Authorization: Bearer")]
        [Delete("/{publicId}")]
        public Task Delete(string publicId);

        [Headers("Authorization: Bearer")]
        [Post("/type")]
        public Task CreateProductType(string name, string[] properties);

        [Get("/type")]
        [Headers("Authorization: Bearer")]
        public Task<List<ProductTypeModel>> GetAllProductTypes();
    }
}
