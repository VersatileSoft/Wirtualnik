using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Repository.Interfaces;
using Wirtualnik.Repository.Repositories.Base;

namespace Wirtualnik.Repository.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>, IShopRepository
    {
        public ShopRepository(WirtualnikDbContext dbContext) : base(dbContext)
        {
        }
    }
}
