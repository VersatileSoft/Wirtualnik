using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.ProductType;

namespace Wirtualnik.Service.Services
{
    public class ProductTypeService : ServiceBase, IProductTypeService
    {
        public ProductTypeService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<ProductType> FetchAsync(string publicId)
        {
            return await Context.ProductTypes.Include(p => p.PropertyTypes).SingleAsync(p => p.PublicId == publicId);
        }

        public async Task<List<ProductTypeModel>> GetAllProductTypes()
        {
            return Mapper.Map<List<ProductTypeModel>>(await Context.ProductTypes.Include(t => t.PropertyTypes).ToListAsync());
        }
    }
}