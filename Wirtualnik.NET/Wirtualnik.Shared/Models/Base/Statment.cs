using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Wirtualnik.Shared.Models.Base
{
    public class Statement
    {
        public HttpStatusCode Code { get; }

        public string? Message { get; set; }

        public Statement(HttpStatusCode code = HttpStatusCode.OK, string? message = null)
        {
            Code = code;
            Message = message;
        }
    }
}
