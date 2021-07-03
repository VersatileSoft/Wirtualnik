using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
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