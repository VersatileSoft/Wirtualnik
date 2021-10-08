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
        Task<Cart> CreateCart(ClaimsPrincipal user);
        Task Add(Product product, Cart cart);
        Task<Cart> FetchAsync(string? temporaryId, ClaimsPrincipal user);
        Task<Cart> FetchAsync(int cartId);
        Task<bool> IsInCart(Product product, Cart cart);
    }
}
