using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Server.Interfaces.Base;
using Wirtualnik.Shared;

namespace Wirtualnik.Server.Controllers.Base
{
    public abstract class AbstractControllerBase<TModel> : ControllerBase
    {
        private readonly IServiceBase<TModel> _serviceBase;
        protected AbstractControllerBase(IServiceBase<TModel> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        [HttpGet("all")]
        public virtual Task<IEnumerable<TModel>> AllAsync()
        {
            return _serviceBase.AllAsync();
        }

        [HttpGet("{id}")]
        public virtual Task<TModel> ByIdAsync(int id)
        {
            return _serviceBase.ByIdAsync(id);
        }

        [HttpPost]
        public virtual Task CreateAsync([FromBody] TModel value)
        {
            return _serviceBase.CreateAsync(value);
        }

        [HttpPut("{id}")]
        public virtual Task UpdateAsync(int id, [FromBody] TModel value)
        {
            return _serviceBase.UpdateAsync(id, value);
        }

        [HttpDelete("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _serviceBase.DeleteAsync(id);
        }
    }
}