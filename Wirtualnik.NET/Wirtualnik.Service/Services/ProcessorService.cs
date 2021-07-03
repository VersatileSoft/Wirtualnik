using AutoMapper;
using System.Linq;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Shared.Models.Processor;

namespace Wirtualnik.Service.Services
{
    public class ProcessorService : ProductService<Processor, FilterModel>, IProcessorService
    {
        public ProcessorService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override void Filter(IQueryable<Processor> query, FilterModel filter)
        {
            base.Filter(query, filter);

            if (!string.IsNullOrEmpty(filter.BaseFrequency))
            {
                query = query.Where(p => p.BaseFrequency == filter.BaseFrequency);
            }
        }
    }
}