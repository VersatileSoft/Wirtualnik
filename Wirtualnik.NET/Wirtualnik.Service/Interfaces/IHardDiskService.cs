using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.HardDisk;

namespace Wirtualnik.Server.Interfaces
{
    public interface IHardDiskService : IProductService<HardDisk, FilterModel>
    { }
}