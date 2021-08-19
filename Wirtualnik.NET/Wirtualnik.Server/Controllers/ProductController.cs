using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Pagination<ListItemModel>>> Search([FromQuery] Pager pager, [FromQuery] FilterModel filter, [FromQuery] Dictionary<string, string> dynamicFilter)
        {
            var list = _mapper.Map<List<ListItemModel>>(await _productService.GetProductsAsync(pager, filter, dynamicFilter));
            return TPagination.FromT(list, pager.TotalRows);
        }

        [HttpGet("{publicId}")]
        [AllowAnonymous]
        public async Task<ActionResult<DetailsModel>> Fetch(string publicId)
        {
            var model = await _productService.FetchAsync(publicId);

            if (model is null)
                return NotFound();

            return _mapper.Map<DetailsModel>(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateModel model)
        {
            var product = _mapper.Map<Product>(model);
            await _productService.CreateAsync(product);
            product = await _productService.FetchAsync(product.PublicId);

            return CreatedAtAction(nameof(this.Fetch), this.GetType().Name.Replace("Controller", ""), new { publicId = product.PublicId }, _mapper.Map<DetailsModel>(product));
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
        }
    }
}