using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models.Base;
using Wirtualnik.Repository.Interfaces.Base;
using Wirtualnik.Server.Interfaces.Base;

namespace Wirtualnik.Server.Services.Base
{
    public abstract class ServiceBase<TModel, TEntity> : IServiceBase<TModel> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IMapper _mapper;

        //protected string CurrentUserId => _repositoryBase.CurrentUserId;

        protected const string NotAllowedError = "This item is not yours or not exsists";

        protected ServiceBase(IRepositoryBase<TEntity> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public async Task<ActionResult> CreateAsync(TModel value)
        {
            var entity = _mapper.Map<TEntity>(value);
            //entity.UserId = CurrentUserId;

            await _repositoryBase.CreateAsync(entity).ConfigureAwait(false);
            return new CreatedResult(string.Empty, entity);
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            var entity = await _repositoryBase.ByIdAsync(id).ConfigureAwait(false);

            //if (!AuthorizeResources(out var res, entity))
            //{
            //    return res;
            //}

            await _repositoryBase.DeleteAsync(entity).ConfigureAwait(false);
            return new OkResult();
        }

        public async Task<ActionResult<TModel>> ByIdAsync(int id)
        {
            var entity = await _repositoryBase.ByIdAsync(id).ConfigureAwait(false);

            //if (!AuthorizeResources(out var res, entity))
            //{
            //    return res;
            //}

            return _mapper.Map<TModel>(entity);
        }

        public async Task<ActionResult<IEnumerable<TModel>>> AllAsync()
        {
            return new OkObjectResult(_mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(await _repositoryBase.AllAsync().ConfigureAwait(false)));
        }

        public async Task<ActionResult> UpdateAsync(int id, TModel value)
        {
            var entity = await _repositoryBase.ByIdAsync(id).ConfigureAwait(false);

            //if (!AuthorizeResources(out var res, entity))
            //{
            //    return res;
            //}

            _mapper.Map(value, entity);
            entity.Id = id;

            await _repositoryBase.UpdateAsync(entity).ConfigureAwait(false);
            return new OkResult();
        }

        //protected bool AuthorizeResources(out ActionResult result, params EntityBase[] resources)
        //{
        //    result = null;
        //    foreach (var resource in resources)
        //    {
        //        if (resource == null)
        //        {
        //            result = new NotFoundResult();
        //            return false;
        //        }

        //        if (resource.UserId != CurrentUserId)
        //        {
        //            result = new UnauthorizedResult();
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
