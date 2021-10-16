using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.ArithmeticExpressionParser;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Extensions.Cart;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Cart;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/cart")]
    [Authorize(Roles = "Admin")]
    public class CartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, IMapper mapper, IProductService productService)
        {
            _cartService = cartService;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<DetailsModel>> FetchCart()
        {
            var model = await _cartService.FetchAsync(this.GetCartTempId(), User);

            if (model is null)
                return NotFound();

            var res = _mapper.Map<DetailsModel>(model);

            foreach(var prod in res.Products)
            {
                prod.Image = await _productService.GetProductListItemImage(prod.PublicId);
            }

            return res;
        }

        [HttpGet("warnings")]
        [AllowAnonymous]
        public async Task<ActionResult<List<WarningModel>>> GetWarnings()
        {
            var cart = await _cartService.FetchAsync(this.GetCartTempId(), User);

            var result = await _cartService.Validate(cart);

            return Ok(_mapper.Map<List<WarningModel>>(result));
        }

        [HttpPost("add/{productId}")]
        [AllowAnonymous]
        public async Task<ActionResult<AddingResultModel>> Add(string productId)
        {
            Product product = await _productService.FetchAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            Cart cart = !string.IsNullOrEmpty(this.GetCartTempId()) ? await _cartService.FetchAsync(this.GetCartTempId(), User) : await _cartService.CreateCart(User);
            await _cartService.Add(product, cart);
            cart = await _cartService.FetchAsync(cart.Id);

            return Ok(new DetailsModel
            {
                Quantity = cart.Products.Count,
                TemporaryId = cart.TemporaryId
            });
        }
    }
}