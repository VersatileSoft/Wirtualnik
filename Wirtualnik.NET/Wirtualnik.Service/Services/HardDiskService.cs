using AutoMapper;
using System.Linq;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
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