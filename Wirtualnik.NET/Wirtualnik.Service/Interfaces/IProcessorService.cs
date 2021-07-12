using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Processor;

namespace Wirtualnik.Server.Interfaces
{
    public interface IProcessorService : IProductService<Processor, FilterModel>
    { }
}