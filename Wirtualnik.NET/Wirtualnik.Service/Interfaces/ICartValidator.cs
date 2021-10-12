using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Models;

namespace Wirtualnik.Service.Interfaces
{
    public interface ICartValidator
    {
        public string Title { get; }
        public string Message { get; }
        public CartWarningType Type { get; }
        public Task<bool> Validate(Cart cart);
    }
}
