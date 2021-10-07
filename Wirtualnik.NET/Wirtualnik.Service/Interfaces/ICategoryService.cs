using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.Category;

namespace Wirtualnik.Service.Interfaces
{
    public interface ICategoryService : IServiceBase
    {
        Task<List<CategoryModel>> GetAllCategories();
        Task<Category> FetchAsync(string publicId);
    }
}