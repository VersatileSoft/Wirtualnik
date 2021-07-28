using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/product")]
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
        public async Task<ActionResult<Pagination<ListItemModel>>> Search([FromQuery] Pager pager, [FromQuery] Dictionary<string, string> filter)
        {
            var list = _mapper.Map<List<ListItemModel>>(await _productService.GetProductsAsync(pager, filter));
            return TPagination.FromT(list, pager.TotalRows);
        }

        [HttpGet("{publicId}")]
        public async Task<ActionResult<DetailsModel>> Fetch(string publicId)
        {
            var model = await _productService.Fetch(publicId);

            if (model is null)
                return NotFound();

            return _mapper.Map<DetailsModel>(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([FromForm] CreateModel model, [FromForm] List<IFormFile> images)
        {
            var product = _mapper.Map<Product>(model);
            product = await _productService.CreateAsync(product);
            await _productService.SaveImages(images.ToList(), product.Id);
            product = await _productService.Fetch(product.PublicId);

            return CreatedAtAction(nameof(this.Fetch), this.GetType().Name.Replace("Controller", ""), new { publicId = product.PublicId }, _mapper.Map<DetailsModel>(product));
        }

        [HttpPost("type")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateProductType(string name, string[] properties)
        {
            ProductType productType = new ProductType
            {
                Name = name,
                ProductProperties = properties.Select(p => new PropertyType { Name = p }).ToList()
            };

            await _productService.CreateAsync(productType);

            return Ok();
        }

        [HttpGet("type")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllProductTypes()
        {
            List<ProductTypeModel> types = await _productService.GetAllProductTypes();

            return Ok(types);
        }

        [HttpPut("{publicId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(string publicId, CreateModel model)
        {
            var entity = await _productService.Fetch(publicId);

            if (entity == null)
                return NotFound();

            var result = _mapper.Map(model, entity);

            await _productService.UpdateAsync(result);

            return Accepted();
        }

        [HttpDelete("{publicId}")]
        public async Task<ActionResult> Delete(string publicId)
        {
            var entity = await _productService.Fetch(publicId);

            if (entity == null)
                return NotFound();

            await _productService.RemoveAsync(entity);

            return Accepted();
        }
    }
}
