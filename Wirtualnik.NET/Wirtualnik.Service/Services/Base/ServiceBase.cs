using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Repository.Interfaces.Base;
using Wirtualnik.Server.Interfaces.Base;

namespace Wirtualnik.Services.Base
{
    public abstract class ServiceBase<TModel, TEntity> : IServiceBase<TModel> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IMapper _mapper;

        protected ServiceBase(IRepositoryBase<TEntity> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public async Task CreateAsync(TModel value)
        {
            var entity = _mapper.Map<TEntity>(value);
            await _repositoryBase.CreateAsync(entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repositoryBase.ByIdAsync(id).ConfigureAwait(false);
            await _repositoryBase.DeleteAsync(entity).ConfigureAwait(false);
        }

        public async Task<TModel> ByIdAsync(int id)
        {
            var entity = await _repositoryBase.ByIdAsync(id).ConfigureAwait(false);

            return _mapper.Map<TModel>(entity);
        }

        public async Task<IEnumerable<TModel>> AllAsync()
        {
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(await _repositoryBase.AllAsync().ConfigureAwait(false));
        }

        public async Task UpdateAsync(int id, TModel value)
        {
            var entity = await _repositoryBase.ByIdAsync(id).ConfigureAwait(false);

            _mapper.Map(value, entity);
            entity.Id = id;

            await _repositoryBase.UpdateAsync(entity).ConfigureAwait(false);
        }
    }
}
