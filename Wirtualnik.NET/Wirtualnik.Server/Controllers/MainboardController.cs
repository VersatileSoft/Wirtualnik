using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Mainboard;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/mainboard")]
    public class MainboardController : ProductController<Mainboard, FilterModel, ListItemModel, DetailsModel, CreateModel>
    {
        public MainboardController(IProductService<Mainboard, FilterModel> productService, IMapper mapper) : base(productService, mapper)
        {
        }
    }
}