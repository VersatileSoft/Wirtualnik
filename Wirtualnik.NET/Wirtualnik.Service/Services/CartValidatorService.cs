using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;

namespace Wirtualnik.Service.Services
{
    public class CartValidatorService : ServiceBase, ICartValidatorService
    {
        public CartValidatorService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
