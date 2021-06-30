using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Repository.Interfaces;
using Wirtualnik.Repository.Interfaces.Base;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Services.Base;
using Wirtualnik.Shared.Models;

namespace Wirtualnik.Service.Services
{
    public class ShopService : ServiceBase<ShopModel, Shop>, IShopService
    {
        public ShopService(IShopRepository repositoryBase, IMapper mapper) : base(repositoryBase, mapper)
        {
        }
    }
}