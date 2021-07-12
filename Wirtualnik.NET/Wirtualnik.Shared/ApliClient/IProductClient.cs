using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.ApliClient
{
    public interface IProductClient<TDetailsModel, TFilter, TListItemModel, TCreateModel>
        where TFilter : ProductFilter
        where TListItemModel : class
        where TDetailsModel : class
    {
        [Get("")]
        public Task<Pagination<Resource<TListItemModel>>> Search([Query] Pager pager, [Query] TFilter filter);

        [Get("/{id}")]
        public Task<Resource<TDetailsModel>> Fetch(Guid id);

        [Post("")]
        public Task Create(TCreateModel model);

        [Put("/{id}")]
        public Task Update(Guid id, TCreateModel model);

        [Delete("/{id}")]
        public Task Delete(Guid id);

    }
}
