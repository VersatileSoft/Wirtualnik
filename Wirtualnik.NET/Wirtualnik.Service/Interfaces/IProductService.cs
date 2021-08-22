using Microsoft.AspNetCore.Http;
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
        Task<IEnumerable<Product>> GetProductsAsync(Pager pager, FilterModel filter, Dictionary<string, string> dynamicFilter);
        Task<Product> FetchAsync(string publicId);
        Task XlsxImport(IFormFile file, string productTypeId);
    }
}