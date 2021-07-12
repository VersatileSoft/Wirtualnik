using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
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