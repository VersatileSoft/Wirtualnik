using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wirtualnik.ArithmeticExpressionParser;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Extensions;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;

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

        public async Task<Cart> CreateCart(ClaimsPrincipal user)
        {
            Cart? cart = null;
            var currentUser = await _userManager.FindByIdAsync(user.Id());
            if (currentUser != null)
            {
                cart = await Context.Carts.FirstOrDefaultAsync(c => c.UserId == currentUser.Id);
            }

            return cart ?? await CreateAsync(new Cart
            {
                CreateDate = DateTime.Now,
                TemporaryId = currentUser == null ? Guid.NewGuid().ToString() : null,
                UserId = currentUser?.Id
            });
        }

        public async Task Add(Product product, Cart cart)
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

            cart.TemporaryId = Guid.NewGuid().ToString();
            await UpdateAsync(cart);
        }

        public async Task<Cart> FetchAsync(string? temporaryId, ClaimsPrincipal user)
        {
            var query = Context.Carts
                .Include(c => c.Products)
                .ThenInclude(c => c.ProductProperties)
                .ThenInclude(c => c.CategoryProperty)
                .Include(c => c.Products)
                .ThenInclude(p => p.Category);

            var id = user.Id();
            var currentUser = await _userManager.FindByIdAsync(id);
            if (currentUser != null)
            {
                return await query.FirstOrDefaultAsync(c => c.UserId == currentUser.Id);
            }
            return await query.FirstOrDefaultAsync(c => c.TemporaryId == temporaryId);
        }

        public async Task<Cart> FetchAsync(int id)
        {
            return await Context.Carts
                .Where(c => c.Id == id)
                .Include(c => c.Products)
                .ThenInclude(c => c.ProductProperties)
                .ThenInclude(c => c.CategoryProperty)
                .Include(c => c.Products)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> IsInCart(Product product, Cart cart)
        {
            return (await FetchAsync(cart.Id)).Products.Select(p => p.Id).Contains(product.Id);
        }

        public async Task<List<CartValidator>> Validate(Cart cart)
        {
            var res = (await Context
                .CartValidators
                .ToListAsync())
                .Where(v => Expression.Evaluate(v.ValidationExpression, cart))
                .ToList();

            foreach (var p in res)
            {
                p.Message = StringParserEvaluator.Evaluate(p.Message, cart);
            }
            return res;
        }
    }
}
