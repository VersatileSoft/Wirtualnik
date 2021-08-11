using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.ProductType;

namespace Wirtualnik.Service.Interfaces
{
    public interface IProductTypeService : IServiceBase
    {
        Task<List<ProductTypeModel>> GetAllProductTypes();
        Task<ProductType> FetchAsync(string publicId);
    }
}