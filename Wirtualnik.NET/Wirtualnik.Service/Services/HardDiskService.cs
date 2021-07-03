using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.HardDisk;

namespace Wirtualnik.Service.Services
{
    public class HardDiskService : ProductService<HardDisk, FilterModel>, IHardDiskService
    {
        public HardDiskService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override void Filter(IQueryable<HardDisk> query, FilterModel filter)
        {
            base.Filter(query, filter);

           
        }
    }
}