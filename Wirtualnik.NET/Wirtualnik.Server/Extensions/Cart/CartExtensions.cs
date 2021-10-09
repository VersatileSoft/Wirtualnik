using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wirtualnik.Server.Extensions.Cart
{
    public static class CartExtensions
    {
        public static int? GetCart(this ControllerBase controllerBase)
        {
            return controllerBase.HttpContext.Items["CartId"] as int?;
        }
    }
}
