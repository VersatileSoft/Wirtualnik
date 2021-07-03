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
using Wirtualnik.Shared.Models.Memory;

namespace Wirtualnik.Service.Services
{
    public class MemoryService : ProductService<Memory, FilterModel>, IMemoryService
    {
        public MemoryService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override void Filter(IQueryable<Memory> query, FilterModel filter)
        {
            base.Filter(query, filter);

        }
    }
}