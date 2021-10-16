using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Service.Interfaces;

namespace Wirtualnik.Server.Extensions.Middlewares
{
    public class CartMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ICartService _cartService;

        public CartMiddleware(RequestDelegate next, ICartService cartService)
        {
            this.next = next;
            this._cartService = cartService;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["CartTempId"] = context.Request.Headers["cart-id"].ToString();
            await next(context);
        }
    }

    public static class CartMiddlewareExtensions
    {
        public static IApplicationBuilder UseCart(this IApplicationBuilder app)
        {
            app.UseMiddleware<CartMiddleware>();
            return app;
        }
    }
}
