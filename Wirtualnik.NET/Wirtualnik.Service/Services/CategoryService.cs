using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Category;

namespace Wirtualnik.Service.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<Category> FetchAsync(string publicId)
        {
            return await Context.Categories.Include(p => p.CategoryProperties).SingleAsync(p => p.PublicId == publicId);
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return Mapper.Map<List<CategoryModel>>(await Context.Categories.Include(t => t.CategoryProperties).ToListAsync());
        }
    }
}