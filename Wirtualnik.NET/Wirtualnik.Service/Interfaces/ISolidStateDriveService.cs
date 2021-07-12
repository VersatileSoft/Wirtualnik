using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.SolidStateDrive;

namespace Wirtualnik.Server.Interfaces
{
    public interface ISolidStateDriveService : IProductService<SolidStateDrive, FilterModel>
    { }
}