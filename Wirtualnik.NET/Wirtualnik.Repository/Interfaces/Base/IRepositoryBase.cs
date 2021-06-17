using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wirtualnik.Repository.Interfaces.Base
{
    public interface IRepositoryBase<TEntity>
    {
        Task CreateAsync(TEntity value);
        Task DeleteAsync(TEntity id);
        Task<TEntity> ByIdAsync(int id);
        Task<IEnumerable<TEntity>> AllAsync();
        Task UpdateAsync(TEntity value);
    }
}