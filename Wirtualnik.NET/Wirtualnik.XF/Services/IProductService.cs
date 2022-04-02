using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.XF.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ListItemModel>> Search(Pager pager, FilterModel filter, Dictionary<string, string> dynamicFilter);

        public Task<DetailsModel> Fetch(string publicId);
    }
}