using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IImportClient
    {
        [Multipart]
        [Headers("Authorization: Bearer")]
        [Post("/{productTypeId}")]
        public Task<HttpResponseMessage> ExcelImport(string productTypeId, StreamPart file);
    }
}
