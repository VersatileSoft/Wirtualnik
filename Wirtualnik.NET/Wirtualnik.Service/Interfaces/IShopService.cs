using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;

namespace Wirtualnik.Service.Interfaces
{
    public interface IShopService : IServiceBase
    {
        public Task UpdateProductShop();
        Task<List<Shop>> Search();
    }
}