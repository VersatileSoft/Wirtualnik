using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wirtualnik.Server.Interfaces.Base
{
    public interface IServiceBase<TModel>
    {
        Task<IEnumerable<TModel>> AllAsync();
        Task<TModel> ByIdAsync(int id);
        Task CreateAsync(TModel value);
        Task UpdateAsync(int id, TModel value);
        Task DeleteAsync(int id);
    }
}