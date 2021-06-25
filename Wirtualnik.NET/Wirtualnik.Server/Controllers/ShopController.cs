using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Server.Controllers.Base;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/shop")]
    public class ShopController : AbstractControllerBase<ShopModel>
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService processorService) : base(processorService)
        {
            _shopService = processorService;
        }
    }
}
