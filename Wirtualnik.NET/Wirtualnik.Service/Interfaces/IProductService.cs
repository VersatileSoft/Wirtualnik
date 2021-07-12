using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.Base;

namespace Wirtualnik.Service.Interfaces
{
    public interface IProductService<TEntity, TFilter> : IServiceBase where TEntity : Product
    {
        Task<IEnumerable<TEntity>> GetProductsAsync(Pager pager, TFilter filter);
    }
}