using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Graphic;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/graphic")]
    public class GraphicController : ProductController<Graphic, FilterModel, ListItemModel, DetailsModel, CreateModel>
    {
        public GraphicController(IGraphicService productService, IMapper mapper) : base(productService, mapper)
        {
        }
    }
}