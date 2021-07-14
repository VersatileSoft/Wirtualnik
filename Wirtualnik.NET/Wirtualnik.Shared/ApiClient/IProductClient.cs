using Refit;
using System;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IProductClient<TDetailsModel, TFilter, TListItemModel, TCreateModel>
        where TFilter : ProductFilter
        where TListItemModel : class
        where TDetailsModel : class
    {
        [Get("")]
        public Task<ApiResponse<Pagination<Resource<TListItemModel>>>> Search([Query] Pager pager, [Query] TFilter filter);

        [Get("/{id}")]
        public Task<ApiResponse<Resource<TDetailsModel>>> Fetch(Guid id);

        [Post("")]
        public Task Create(TCreateModel model);

        [Put("/{id}")]
        public Task Update(Guid id, TCreateModel model);

        [Delete("/{id}")]
        public Task Delete(Guid id);

    }
}