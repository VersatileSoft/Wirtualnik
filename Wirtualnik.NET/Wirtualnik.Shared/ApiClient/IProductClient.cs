using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IProductClient
    {
        [Get("")]
        public Task<Pagination<Resource<ListItemModel>>> Search([Query] Pager pager, [Query] Dictionary<string, string> filter);

        [Get("/{publicId}")]
        public Task<Resource<DetailsModel>> Fetch(string publicId);

        [Post("")]
        public Task Create(CreateModel model);

        [Put("/{publicId}")]
        public Task Update(string publicId, CreateModel model);

        [Delete("/{publicId}")]
        public Task Delete(string publicId);

    }
}
