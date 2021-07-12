using AutoMapper;
using System.Linq;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Graphic;

namespace Wirtualnik.Service.Services
{
    public class GraphicService : ProductService<Graphic, FilterModel>, IGraphicService
    {
        public GraphicService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override void Filter(IQueryable<Graphic> query, FilterModel filter)
        {
            base.Filter(query, filter);


        }
    }
}