using Acr.UserDialogs;
using Polly;
using Refit;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Wirtualnik.Shared.ApiClient;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.XF.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductClient productClient;

        public ProductService(IProductClient productClient)
        {
            this.productClient = productClient;
        }

        public async Task<IEnumerable<ListItemModel>> Search(Pager pager, FilterModel filter, Dictionary<string, string> dynamicFilter)
        {
            // Handle both exceptions and return values in one policy
            HttpStatusCode[] httpStatusCodesWorthRetrying =
            {
                HttpStatusCode.RequestTimeout, // 408
                HttpStatusCode.InternalServerError, // 500
                HttpStatusCode.BadGateway, // 502
                HttpStatusCode.ServiceUnavailable, // 503
                HttpStatusCode.GatewayTimeout, // 504
                HttpStatusCode.NotFound // 404
            };

            ApiResponse<Pagination<ListItemModel>> result = null!;

            try
            {
                result = await Policy
                    .Handle<ApiException>()
                    .OrResult<ApiResponse<Pagination<ListItemModel>>>(r => httpStatusCodesWorthRetrying.Contains(r.StatusCode))
                    .RetryAsync()
                    .ExecuteAsync(async () => await this.productClient.Search(pager, filter, dynamicFilter).ConfigureAwait(false))
                    .ConfigureAwait(false);
            }
            catch (ApiException ex)
            {
                SentrySdk.CaptureException(ex);
                await UserDialogs.Instance.AlertAsync(ex.StackTrace, ex.InnerException.Message, "Ok").ConfigureAwait(false);
            }

            //var result = await this.productClient.Search(new Pager(), new Dictionary<string, string>()).ConfigureAwait(false);

            if (result is null || result.Content is null)
            {
                return default!;
            }

            return result.Content.Items;
        }

        public Task<DetailsModel> Fetch(string publicId)
        {
            throw new NotImplementedException();
        }
    }
}