using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Mainboard;

namespace Wirtualnik.Server.Interfaces
{
    public interface IMainboardService : IProductService<Mainboard, FilterModel>
    { }
}