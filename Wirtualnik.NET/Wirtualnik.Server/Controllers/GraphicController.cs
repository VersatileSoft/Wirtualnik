using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
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