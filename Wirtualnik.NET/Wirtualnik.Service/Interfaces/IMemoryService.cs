using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Memory;

namespace Wirtualnik.Server.Interfaces
{
    public interface IMemoryService : IProductService<Memory, FilterModel>
    { }
}