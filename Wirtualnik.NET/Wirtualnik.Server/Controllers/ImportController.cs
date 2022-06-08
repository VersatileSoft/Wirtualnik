using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Service.Interfaces;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/product/import")]
    [Authorize(Roles = "Admin")]
    public class ImportController : ControllerBase
    {
        private IImportService _importService;
        public ImportController(IImportService importService)
        {
            _importService = importService;
        }

        [HttpPost("{productTypeId}")]
        public async Task<ActionResult> ExcelImport(string productTypeId, [FromForm] List<IFormFile> file)
        {
            await _importService.XlsxImport(file[0], productTypeId);
            return Ok();
        }
    }
}