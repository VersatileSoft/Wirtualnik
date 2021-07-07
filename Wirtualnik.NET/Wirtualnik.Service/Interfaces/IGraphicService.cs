using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Shared.Models.Graphic;

namespace Wirtualnik.Service.Interfaces
{
    public interface IGraphicService : IProductService<Graphic, FilterModel>
    { }
}