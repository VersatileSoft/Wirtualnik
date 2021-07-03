using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Memory;

namespace Wirtualnik.Server.Interfaces
{
    public interface IMemoryService : IProductService<Memory, FilterModel>
    { }
}