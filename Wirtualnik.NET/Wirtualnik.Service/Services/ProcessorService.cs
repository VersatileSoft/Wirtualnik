using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Processor;

namespace Wirtualnik.Service.Services
{
    public class ProcessorService : ServiceBase, IProcessorService
    {
        public ProcessorService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public Task<Processor> CreateAsync(CreateModel model)
        {
            var processor = Mapper.Map<Processor>(model);
            return CreateAsync(processor);
        }

        public async Task<IEnumerable<Processor>> GetProcessorsAsync()
        {
            return await Context.Processors.ToListAsync();
        }
    }
}