using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Shared.Models.HardDisk;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/hard_disk")]
    public class HardDiskController : ProductController<HardDisk, FilterModel, ListItemModel, DetailsModel, CreateModel>
    {
        public HardDiskController(IHardDiskService productService, IMapper mapper) : base(productService, mapper)
        {
        }
    }
}