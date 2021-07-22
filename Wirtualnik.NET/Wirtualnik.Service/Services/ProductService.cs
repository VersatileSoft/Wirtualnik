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
            return Context.Products.Include(p => p.Properties).ThenInclude(p => p.PropertyType).Include(p => p.ProductType).FirstOrDefaultAsync(p => p.PublicId == publicId);
        }

        public async Task<List<ProductTypeModel>> GetAllProductTypes()
        {
            return await Context.ProductTypes.Include(t => t.ProductProperties).Select(p => new ProductTypeModel
            {
                Id = p.Id,
                Name = p.Name,
                PropertyTypes = p.ProductProperties.Select(t => new KeyValuePair<int, string>(t.Id, t.Name)).ToList()
            }).ToListAsync();
        }

        public async Task<IEnumerable<ListItemModel>> GetProductsAsync(Pager pager, Dictionary<string, string> filter)
        {
            var query = Context.Products.Include(p => p.Properties).ThenInclude(p => p.PropertyType).Include(p => p.ProductType).AsQueryable();

            if (filter.TryGetValue("ProductTypeId", out string stringValue) && int.TryParse(stringValue, out int value) )
                query = query.Where(p => p.ProductTypeId == value);

            foreach(var property in filter)
            {
                query = query.Where(product => product.Properties.Any(prop => prop.PropertyType.Name == property.Key) ?
                product.Properties.Single(prop => prop.PropertyType.Name == property.Key).Value == property.Value : true);
            }

            return Mapper.Map<List<ListItemModel>>(await query.Paginate(pager).ToListAsync());

        }

        public Task<bool> UpdateAsync(CreateModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
