using AutoMapper;
using System.Linq;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
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