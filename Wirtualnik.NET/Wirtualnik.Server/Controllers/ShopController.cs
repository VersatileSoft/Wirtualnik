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
            var k = await _shopService.Search();
            return Ok(k);
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            await _shopService.CreateAsync(new Shop
            {
                Name = "Rtv euro agd",
                ParserName = "tradedoubler",
                AdditionalParserInfo = "21618",
            });

            await _shopService.CreateAsync(new Shop
            {
                Name = "Neonet",
                ParserName = "tradedoubler",
                AdditionalParserInfo = "21986",
            });

            await _shopService.CreateAsync(new Shop
            {
                Name = "Avans",
                ParserName = "tradedoubler",
                AdditionalParserInfo = "25545",
            });

            await _shopService.CreateAsync(new Shop
            {
                Name = "OleOle",
                ParserName = "tradedoubler",
                AdditionalParserInfo = "17354",
            });

            await _shopService.CreateAsync(new Shop
            {
                Name = "Electro",
                ParserName = "tradedoubler",
                AdditionalParserInfo = "23757",
            });

            await _shopService.CreateAsync(new Shop
            {
                Name = "Zadowolenie",
                ParserName = "tradedoubler",
                AdditionalParserInfo = "24688",
            });

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