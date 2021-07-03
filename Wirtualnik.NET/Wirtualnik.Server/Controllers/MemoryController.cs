using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Memory;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/memory")]
    public class MemoryController : ProductController<Memory, FilterModel, ListItemModel, DetailsModel, CreateModel>
    {
        public MemoryController(IProductService<Memory, FilterModel> productService, IMapper mapper) : base(productService, mapper)
        {
        }
    }
}