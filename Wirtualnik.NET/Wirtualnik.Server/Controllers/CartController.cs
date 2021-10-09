using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
            var model = await _cartService.FetchAsync(this.GetCart() ?? 0);

            if (model is null)
                return NotFound();

            return _mapper.Map<DetailsModel>(model);
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

            Cart cart = this.GetCart().HasValue ? await _cartService.FetchAsync(this.GetCart()!.Value) : await _cartService.CreateCart(User);
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