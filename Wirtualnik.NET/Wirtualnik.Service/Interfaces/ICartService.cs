using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.Base;
using Wirtualnik.Shared.Models.Cart;

namespace Wirtualnik.Service.Interfaces
{
    public interface ICartService : IServiceBase
    {
        Task<AddingResultModel> Add(string productId, ClaimsPrincipal user, string? temporaryId);
        Task<Cart> FetchAsync(string? temporaryId, ClaimsPrincipal user);
    }
}