using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public ProductService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public Task<Product> FetchAsync(string publicId)
        {
            return Context.Products
                .Include(p => p.Properties).ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.PublicId == publicId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Pager pager, FilterModel filter, Dictionary<string, string> dynamicFilter)
        {
            var query = Context.Products
                .Include(p => p.Properties.Where(p => p.PropertyType.ShowInCell))
                .ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.ProductType))
                query = query.Where(p => p.ProductType.PublicId == filter.ProductType);

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filter.Manufacturer))
                query = query.Where(p => p.Manufacturer.Contains(filter.Manufacturer, StringComparison.OrdinalIgnoreCase));

            foreach (var property in dynamicFilter)
            {
                query = query.Where(product => !product.Properties.Any(prop => prop.PropertyType.Name == property.Key) ||
                product.Properties.Single(prop => prop.PropertyType.Name == property.Key).Value == property.Value);
            }

            return await query.Paginate(pager).ToListAsync();
        }
    }
}
