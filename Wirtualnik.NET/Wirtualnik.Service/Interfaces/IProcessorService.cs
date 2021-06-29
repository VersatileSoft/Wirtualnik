using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.Processor;

namespace Wirtualnik.Server.Interfaces
{
    public interface IProcessorService : IServiceBase
    {
        Task<IEnumerable<Processor>> GetProcessorsAsync();
        Task<Processor> CreateAsync(CreateModel model);
    }
}