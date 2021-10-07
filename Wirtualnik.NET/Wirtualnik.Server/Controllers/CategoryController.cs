using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Category;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/category")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService productTypeService, IMapper mapper)
        {
            _categoryService = productTypeService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAll()
        {
            List<CategoryModel> types = await _categoryService.GetAllCategories();
            return Ok(types);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryModel model)
        {
            Category productType = _mapper.Map<Category>(model);
            var newType = await _categoryService.CreateAsync(productType);
            return CreatedAtAction(nameof(this.GetAll), _mapper.Map<CategoryModel>(newType));
        }

        [HttpPut("{publicId}")]
        public async Task<ActionResult> Update(string publicId, CategoryModel model)
        {
            Category entity = await _categoryService.FetchAsync(publicId);

            if (entity is null)
            {
                return NotFound();
            }

            Category productType = _mapper.Map(model, entity);
            await _categoryService.UpdateAsync(productType);
            return Accepted();
        }

        [HttpDelete("{publicId}")]
        public async Task<ActionResult> Delete(string publicId)
        {
            Category entity = await _categoryService.FetchAsync(publicId);

            if (entity is null)
            {
                return NotFound();
            }

            await _categoryService.RemoveAsync(entity);
            return Accepted();
        }
    }
}