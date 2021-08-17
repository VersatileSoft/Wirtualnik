using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> Search()
        {
            return Ok(await _shopService.AllAsync<Shop>());
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            var shop = new Shop
            {
                Name = "HARD PC",
                ParserName = "hard_pc",
            };

            await _shopService.CreateAsync(shop);
            return Ok();
        }

        [HttpPost("manual_refresh_data")]
        public async Task<ActionResult> ManualRefreshData()
        {
            await _shopService.UpdateProductShop();

            return Ok();
        }
    }
}