using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Service.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        private IFilesService _filesService;
        public ProductService(WirtualnikDbContext context, IMapper mapper, IFilesService filesService) : base(context, mapper)
        {
            _filesService = filesService;
        }

        public async Task<Product> FetchAsync(string publicId)
        {
            return await Context.Products
                .Include(p => p.ProductProperties).ThenInclude(p => p.CategoryProperty)
                .Include(p => p.Category)
                .Include(p => p.ProductShops).ThenInclude(p => p.Shop)
                .FirstOrDefaultAsync(p => p.PublicId == publicId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Pager pager, FilterModel filter, Dictionary<string, string> dynamicFilter)
        {
            return await Context.Products
                .Include(p => p.ProductProperties.Where(p => p.CategoryProperty.ShowInCell))
                .ThenInclude(p => p.CategoryProperty)
                .Include(p => p.Category)
                .Include(p => p.ProductShops).ThenInclude(p => p.Shop)
                .Where(Filter(filter, dynamicFilter))
                .Paginate(pager)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetProductDetailsImages(Product product)
        {
            var images = await _filesService.GetImages(product.Images);
            
            return images
                .Where(i => i.Width == 200 && i.Height == 200)
                .OrderByDescending(i => i.Main)
                .Select(i => _filesService.GetImageLink(i.FileName))
                .ToList();
        }

        public async Task<string> GetProductListItemImage(Product product)
        {
            var images = await _filesService.GetImages(product.Images);

            return images
                .Where(i => i.Width == 200 && i.Height == 200 && i.Main)
                .Select(i => _filesService.GetImageLink(i.FileName))
                .FirstOrDefault() ?? "";
        }

        private static ExpressionStarter<Product> Filter(FilterModel filter, Dictionary<string, string> dynamicFilter)
        {
            var predicate = PredicateBuilder.New<Product>();

            if (!string.IsNullOrEmpty(filter.Category))
                predicate.And(p => p.Category.PublicId == filter.Category);

            if (!string.IsNullOrEmpty(filter.Name))
                predicate.And(p => p.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filter.Manufacturer))
                predicate.And(p => p.Manufacturer.Contains(filter.Manufacturer, StringComparison.OrdinalIgnoreCase));

            foreach (var property in dynamicFilter)
            {
                predicate.And(product => !product.ProductProperties.Any(prop => prop.CategoryProperty.Name == property.Key) ||
                product.ProductProperties.Single(prop => prop.CategoryProperty.Name == property.Key).Value == property.Value);
            }

            return predicate;
        }
    }
}