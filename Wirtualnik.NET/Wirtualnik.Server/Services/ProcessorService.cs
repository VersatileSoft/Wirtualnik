using AutoMapper;
using Wirtualnik.Data.Models;
using Wirtualnik.Repository.Interfaces;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Server.Services.Base;
using Wirtualnik.Shared.Models;

namespace Wirtualnik.Server.Services
{
    public class ProcessorService : ServiceBase<ProcessorModel, Processor>, IProcessorService
    {
        public ProcessorService(IProcessorRepository customerRepository, IMapper mapper) : base(customerRepository, mapper)
        {
        }
    }
}
