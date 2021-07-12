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
    public class ProductService<TEntity, TFilter> : ServiceBase, IProductService<TEntity, TFilter> where TEntity : Product where TFilter : ProductFilter
    {
        public ProductService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<IEnumerable<TEntity>> GetProductsAsync(Pager pager, TFilter filter)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            Filter(query, filter);
            return await query.Paginate(pager).ToListAsync();
        }

        protected virtual void Filter(IQueryable<TEntity> query, TFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(p => filter.Name.Contains(p.Name ?? ""));
            }
        }
    }
}
