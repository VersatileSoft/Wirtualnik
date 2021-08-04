using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.ProductType;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/product/type")]
    [Authorize(Roles = "Admin")]
    public class ProductTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeService _productTypeService;
        public ProductTypesController(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ProductTypeModel>>> GetAll()
        {
            List<ProductTypeModel> types = await _productTypeService.GetAllProductTypes();
            return Ok(types);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductTypeModel model)
        {
            ProductType productType = _mapper.Map<ProductType>(model);
            var newType = await _productTypeService.CreateAsync(productType);
            return CreatedAtAction(nameof(this.GetAll), _mapper.Map<ProductTypeModel>(newType));
        }

        [HttpPut("{publicId}")]
        public async Task<ActionResult> Update(string publicId, ProductTypeModel model)
        {
            ProductType entity = await _productTypeService.FetchAsync(publicId);

            if (entity is null)
            {
                return NotFound();
            }

            ProductType productType = _mapper.Map(model, entity);
            await _productTypeService.UpdateAsync(productType);
            return Accepted();
        }

        [HttpDelete("{publicId}")]
        public async Task<ActionResult> Delete(string publicId)
        {
            ProductType entity = await _productTypeService.FetchAsync(publicId);

            if (entity is null)
            {
                return NotFound();
            }

            await _productTypeService.RemoveAsync(entity);
            return Accepted();
        }
    }
}
