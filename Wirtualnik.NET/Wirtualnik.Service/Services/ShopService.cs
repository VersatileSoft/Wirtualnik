using AutoMapper;
using Wirtualnik.Data;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;

namespace Wirtualnik.Service.Services
{
    public class ShopService : ServiceBase, IShopService
    {
        public ShopService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
