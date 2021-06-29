using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Service.Interfaces;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/shop")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService processorService)
        {
            _shopService = processorService;
        }
    }
}
