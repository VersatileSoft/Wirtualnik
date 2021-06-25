using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IAbstractClient<TModel>
    {
        Task<IEnumerable<TModel>> AllAsync();

        Task<TModel> ByIdAsync(int id);

        Task CreateAsync(TModel value);

        Task UpdateAsync(int id, TModel value);

        Task DeleteAsync(int id);
    }
}
