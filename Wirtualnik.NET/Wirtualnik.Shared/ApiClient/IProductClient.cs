﻿using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IProductClient
    {
        [Get("")]
        public Task<ApiResponse<Pagination<ListItemModel>>> Search([Query] Pager pager, [Query] FilterModel filter, [Query] Dictionary<string, string> dynamicFilter);

        [Get("/{publicId}")]
        public Task<ApiResponse<DetailsModel>> Fetch(string publicId);

        [Headers("Authorization: Bearer")]
        [Post("")]
        public Task Create([Body] CreateModel model);

        [Headers("Authorization: Bearer")]
        [Put("/{publicId}")]
        public Task Update(string publicId, CreateModel model);

        [Put("/attach-images/{publicId}")]
        [Headers("Authorization: Bearer")]
        public Task<HttpResponseMessage> AttachImages(string publicId, [Body] List<int> images);

        [Headers("Authorization: Bearer")]
        [Delete("/{publicId}")]
        public Task Delete(string publicId);
    }
}