using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.SolidStateDrive;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/solid_state_drive")]
    public class SolidStateDriveController : ProductController<SolidStateDrive, FilterModel, ListItemModel, DetailsModel, CreateModel>
    {
        public SolidStateDriveController(IProductService<SolidStateDrive, FilterModel> productService, IMapper mapper) : base(productService, mapper)
        {
        }
    }
}