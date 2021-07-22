using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Service.Interfaces
{
    public interface IProductService : IServiceBase
    {
        Task<IEnumerable<ListItemModel>> GetProductsAsync(Pager pager, Dictionary<string, string> filter);
        Task<bool> UpdateAsync(CreateModel model);
        Task<Product> Fetch(string publicId);
        Task<List<ProductTypeModel>> GetAllProductTypes();
    }
}