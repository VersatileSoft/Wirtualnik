using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Extensions;
using Wirtualnik.Shared.ApiClient;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;
using Wirtualnik.XF.PageModels.Base;
using Wirtualnik.XF.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.ViewModels
{
    public class CreateViewModel : BaseTabbarPageViewModel
    {
        private readonly IProductService productService;

        public int remainingItemsThreshold { get; set; } = -1;
        public bool IsLoaded { get; set; }

        public SafeObservableCollection<ListItemModel> ProductList { get; set; }

        private AsyncCommand? loadMoreItemsCommand;
        public AsyncCommand LoadMoreItemsCommand => loadMoreItemsCommand ??= new AsyncCommand(async () => await LoadMoreDataAsync().ConfigureAwait(false), allowsMultipleExecutions: false);

        private AsyncCommand? refreshListCommand;
        public AsyncCommand RefreshListCommand => refreshListCommand ??= new AsyncCommand(async () =>
        {
            remainingItemsThreshold = -1;
            pageIndex = 0;
            ProductList.Clear();
            IsLoaded = false;
            await LoadDataAsync().ConfigureAwait(false);
        }, allowsMultipleExecutions: false);

        public CreateViewModel(INavigationService navigationService, IProductService productService) : base(navigationService)
        {
            this.productService = productService;

            ProductList = new SafeObservableCollection<ListItemModel>();
        }

        public override async Task Initialize()
        {
            await LoadDataAsync().ConfigureAwait(false);

            return;
        }

        private async Task LoadDataAsync()
        {
            if (IsLoaded)
            {
                return;
            }

            var pager = new Pager();
            pager.PageIndex = 0;

            var result = await this.productService.Search(pager, new Dictionary<string, string>()).ConfigureAwait(false);

            if (result?.Any() != true)
            {
                return;
            }

            ProductList.AddRange(result);

            IsLoaded = true;
            remainingItemsThreshold = 1;
            return;
        }

        private int pageIndex;
        private async Task LoadMoreDataAsync()
        {
            if (!IsLoaded || ProductList.Count < 8)
            {
                return;
            }

            var pager = new Pager();
            pager.PageIndex = pageIndex++;

            var result = await this.productService.Search(pager, new Dictionary<string, string>()).ConfigureAwait(false);

            if (result?.Any() != true)
            {
                remainingItemsThreshold = -1;
                return;
            }

            ProductList.AddRange(result);

            return;
        }
    }
}