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
using Wirtualnik.Shared.Models.Shop;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IFilesService _filesService;

        public ProductController(IProductService productService, IMapper mapper, IFilesService filesService)
        {
            _productService = productService;
            _mapper = mapper;
            _filesService = filesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Pagination<ListItemModel>>> Search([FromQuery] Pager pager, [FromQuery] FilterModel filter, [FromQuery] Dictionary<string, string> dynamicFilter)
        {
            var products = await _productService.GetProductsAsync(pager, filter, dynamicFilter);
            var result = new List<ListItemModel>();

            foreach(var product in products)
            {
                var model = _mapper.Map<ListItemModel>(product);
                model.Image = (await _productService.GetProductListItemImage(product));
                model.ProductShopDetails = product.ProductShops.Select(p => new ProductShopDetails
                {
                    Name = p.Shop.Name,
                    CleanLink = p.CleanLink,
                    RefLink = p.RefLink,
                    Price = p.Price,
                    Image = _filesService.GetImageLink(p.Shop.ImageId).Result
                });
                result.Add(model);
            }

            return TPagination.FromT(result, pager.TotalRows);
        }

        [HttpGet("{publicId}")]
        [AllowAnonymous]
        public async Task<ActionResult<DetailsModel>> Fetch(string publicId)
        {
            var model = await _productService.FetchAsync(publicId);

            if (model is null)
                return NotFound();

            // TODO Add this madness to mapper
            var shops = model.ProductShops.Select(p => new ProductShopDetails
            {
                Name = p.Shop.Name,
                CleanLink = p.CleanLink,
                RefLink = p.RefLink,
                Price = p.Price,
                Image = _filesService.GetImageLink(p.Shop.ImageId).Result
            });

            var result = _mapper.Map<DetailsModel>(model);
            result.ProductShopDetails = shops;
            result.Images = (await _productService.GetProductDetailsImages(model)).ToList();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateModel model)
        {
            var product = _mapper.Map<Product>(model);
            await _productService.CreateAsync(product);
            product = await _productService.FetchAsync(product.PublicId);

            return CreatedAtAction(nameof(this.Fetch), this.GetType().Name.Replace("Controller", ""), new { publicId = product.PublicId }, _mapper.Map<DetailsModel>(product));
        }

        [HttpPut("attach-images/{publicId}")]
        public async Task<ActionResult> AttachImages(string publicId, List<int> images)
        {
            var entity = await _productService.FetchAsync(publicId);
            if (entity == null)
                return NotFound();
            entity.Images = images;
            await _productService.UpdateAsync(entity);
            return Accepted();
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