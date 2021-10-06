using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
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
        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<DetailsModel>> FetchCart(string? temporaryId = null)
        {
            var model = await _cartService.FetchAsync(temporaryId, User);

            if (model is null)
                return NotFound();

            return _mapper.Map<DetailsModel>(model);
        }


        [HttpPost("add/{productId}")]
        [AllowAnonymous]
        public async Task<ActionResult<AddingResultModel>> Add(string productId, string? temporaryId = null)
        {
            AddingResultModel result = await _cartService.Add(productId, User, temporaryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        /*        [HttpPost("import/{productTypeId}")]
                public async Task<ActionResult> ExcelImport(string productTypeId, [FromForm] List<IFormFile> file)
                {
                    await _productService.XlsxImport(file[0], productTypeId);
                    return Ok();
                }

                [HttpPut("{publicId}")]
                public async Task<ActionResult> Update(string publicId, CreateModel model)
                {
                    var entity = await _productService.FetchAsync(publicId);

                    if (entity == null)
                        return NotFound();

                    var result = _mapper.Map(model, entity);

                    await _productService.UpdateAsync(result);

                    return Accepted();
                }

                [HttpDelete("{publicId}")]
                public async Task<ActionResult> Delete(string publicId)
                {
                    var entity = await _productService.FetchAsync(publicId);

                    if (entity == null)
                        return NotFound();

                    await _productService.RemoveAsync(entity);

                    return Accepted();
                }*/
    }
}