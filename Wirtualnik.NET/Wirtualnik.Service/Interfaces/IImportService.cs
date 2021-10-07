using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Service.Interfaces.Base;

namespace Wirtualnik.Service.Interfaces
{
    public interface IImportService : IServiceBase
    {
        Task XlsxImport(IFormFile file, string productTypeId);
    }
}
