using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.HardDisk;

namespace Wirtualnik.Server.Interfaces
{
    public interface IHardDiskService : IProductService<HardDisk, FilterModel>
    { }
}