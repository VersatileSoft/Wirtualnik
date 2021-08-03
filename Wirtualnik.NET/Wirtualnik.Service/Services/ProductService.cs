using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public Task<Product> Fetch(string publicId)
        {
            return Context.Products
                .Include(p => p.Properties).ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.PublicId == publicId);
        }

        public async Task<List<ProductTypeModel>> GetAllProductTypes()
        {
            return await Context.ProductTypes.Include(t => t.ProductProperties).Select(p => new ProductTypeModel
            {
                Id = p.Id,
                Name = p.Name,
                PublicId = p.publicId,
                PropertyTypes = p.ProductProperties.Select(t => new PropertyModel { Name = t.Name, Id = t.Id })
            }).ToListAsync();
        }

        public async Task<IEnumerable<ListItemModel>> GetProductsAsync(Pager pager, string typePublicId, Dictionary<string, string> filter)
        {
            var query = Context.Products
                .Include(p => p.Properties.Where(p => p.PropertyType.ShowInCell)).ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .AsQueryable();

            if (!string.IsNullOrEmpty(typePublicId))
                query = query.Where(p => p.ProductType.publicId == typePublicId);

            foreach (var property in filter)
            {
                query = query.Where(product => product.Properties.Any(prop => prop.PropertyType.Name == property.Key) ?
                product.Properties.Single(prop => prop.PropertyType.Name == property.Key).Value == property.Value : true);
            }

            return Mapper.Map<List<ListItemModel>>(await query.Paginate(pager).ToListAsync());
        }

        public Task<bool> UpdateAsync(Shared.Models.Product.CreateModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
