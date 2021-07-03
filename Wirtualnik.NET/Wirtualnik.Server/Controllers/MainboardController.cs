using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
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