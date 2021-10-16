using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wirtualnik.Server.Extensions.Cart
{
    public static class CartExtensions
    {
        public static string? GetCartTempId(this ControllerBase controllerBase)
        {
            return controllerBase.HttpContext.Items["CartTempId"] as string;
        }
    }
}
