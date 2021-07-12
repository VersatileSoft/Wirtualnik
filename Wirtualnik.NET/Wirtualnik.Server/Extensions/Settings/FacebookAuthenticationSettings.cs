using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wirtualnik.Server.Extensions.Settings
{
    public class FacebookAuthenticationSettings
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
}
