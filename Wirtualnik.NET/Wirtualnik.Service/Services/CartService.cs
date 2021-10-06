using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Extensions;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Cart;

namespace Wirtualnik.Service.Services
{
    public class CartService : ServiceBase, ICartService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductService _productService;


        public CartService(WirtualnikDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IProductService productService) : base(context, mapper)
        {
            _userManager = userManager;
            _productService = productService;
        }

        public async Task<AddingResultModel> Add(string productId, ClaimsPrincipal user, string? temporaryId)
        {
            Cart? cart = null;
            var result = new AddingResultModel
            {
                Success = true
            };

            var product = await _productService.FetchAsync(productId);

            if (product == null)
            {
                result.Errors.Add("Nie znaleziono produktu");
                return result;
            }

            var currentUser = await _userManager.FindByIdAsync(user.Id());
            if (currentUser != null)
            {
                cart = await Context.Carts.FirstOrDefaultAsync(c => c.UserId == currentUser.Id);

                if (cart == null)
                {
                    cart = await CreateAsync(new Cart
                    {
                        CreateDate = DateTime.Now,
                        UserId = currentUser.Id
                    });
                }
            }
            else if (!string.IsNullOrEmpty(temporaryId))
            {
                cart = await Context.Carts.Include(c => c.Products).Include(c => c.CartProducts).FirstOrDefaultAsync(c => c.TemporaryId == temporaryId);
                if (cart == null)
                {
                    result.Success = false;
                    result.Errors.Add("Koszyk nie istnieje");
                }
                else
                {
                    cart.TemporaryId = Guid.NewGuid().ToString();
                    result.TemporaryId = cart.TemporaryId;
                    await SaveChangesAsync();
                }
            }
            else
            {
                cart = await CreateAsync(new Cart
                {
                    TemporaryId = Guid.NewGuid().ToString(),
                    CreateDate = DateTime.Now,
                });
                result.TemporaryId = cart.TemporaryId;
            }

            if (cart != null)
            {
                var cartProduct = Context.CartProducts.Where(cp => cp.CartId == cart.Id && cp.ProductId == product.Id).FirstOrDefault();

                if (cartProduct != null)
                {
                    cartProduct.Quantity++;
                    await UpdateAsync(cartProduct);
                }
                else
                {
                    await CreateAsync(new CartProduct
                    {
                        Cart = cart,
                        Product = product,
                        Quantity = 1,
                        CreateDate = DateTime.Now,
                    });
                }

                cart = await Context.Carts.Include(c => c.Products).Include(c => c.CartProducts).FirstOrDefaultAsync(c => c.Id == cart.Id);

                result.Quantity = cart.CartProducts.Sum(p => p.Quantity);
                result.Products = cart.Products.Select(p => p.PublicId).ToList();
                return result;
            }

            result.Errors.Add("Nie udało się utworzyć koszyka");
            result.Success = false;
            return result;
        }

        public async Task<Cart> FetchAsync(string? temporaryId, ClaimsPrincipal user)
        {
            var query = Context.Carts.Include(c => c.Products).ThenInclude(p => p.Images);
            var id = user.Id();
            var currentUser = await _userManager.FindByIdAsync(id);
            if (currentUser != null)
            {
                return await query.FirstOrDefaultAsync(c => c.UserId == currentUser.Id);
            }
            return await query.FirstOrDefaultAsync(c => c.TemporaryId == temporaryId);
        }
    }
}