using System.Threading.Tasks;
using Wirtualnik.Service.Interfaces.Base;

namespace Wirtualnik.Service.Interfaces
{
    public interface IShopService : IServiceBase
    {
        public Task UpdateProductShop();
    }
}