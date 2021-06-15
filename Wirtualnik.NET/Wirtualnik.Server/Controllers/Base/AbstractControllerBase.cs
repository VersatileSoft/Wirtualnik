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

        [HttpGet(CrudPaths.AllPath)]
        public Task<ActionResult<IEnumerable<TModel>>> AllAsync()
        {
            return _serviceBase.AllAsync();
        }

        [HttpGet(CrudPaths.ByIdPath)]
        public Task<ActionResult<TModel>> ByIdAsync(int id)
        {
            return _serviceBase.ByIdAsync(id);
        }

        [HttpPost(CrudPaths.CreatePath)]
        public Task<ActionResult> CreateAsync([FromBody] TModel value)
        {
            return _serviceBase.CreateAsync(value);
        }

        [HttpPut(CrudPaths.UpdatePath)]
        public Task<ActionResult> UpdateAsync(int id, [FromBody] TModel value)
        {
            return _serviceBase.UpdateAsync(id, value);
        }

        [HttpDelete(CrudPaths.DeletePath)]
        public Task<ActionResult> DeleteAsync(int id)
        {
            return _serviceBase.DeleteAsync(id);
        }
    }
}
