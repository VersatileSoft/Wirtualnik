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
using Wirtualnik.Shared.Models.Mainboard;

namespace Wirtualnik.Service.Services
{
    public class MainboardService : ProductService<Mainboard, FilterModel>, IMainboardService
    {
        public MainboardService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override void Filter(IQueryable<Mainboard> query, FilterModel filter)
        {
            base.Filter(query, filter);

        }

    }
}