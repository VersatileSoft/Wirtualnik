using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.SolidStateDrive;

namespace Wirtualnik.Service.Services
{
    public class SolidStateDriveService : ProductService<SolidStateDrive, FilterModel>, ISolidStateDriveService
    {
        public SolidStateDriveService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override void Filter(IQueryable<SolidStateDrive> query, FilterModel filter)
        {
            base.Filter(query, filter);
        }
    }
}