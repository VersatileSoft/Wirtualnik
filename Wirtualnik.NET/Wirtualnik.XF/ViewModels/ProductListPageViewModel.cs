using System.Threading.Tasks;
using Wirtualnik.Extensions;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.ViewModels
{
    public class ProductListPageViewModel : ViewModelBase
    {
        public int remainingItemsThreshold { get; set; } = 1;
        public bool IsLoaded { get; set; }

        public SafeObservableCollection<int> ProductList { get; set; }
        //public DelegateCommand<ProcessorModel> NavigateProductCommand { get; set; }
        public AsyncCommand LoadMoreItemsCommand { get; set; }
        public AsyncCommand LoadedCommand { get; set; }
        public ProductListPageViewModel()
        {
            ProductList = new SafeObservableCollection<int>();

            LoadMoreItemsCommand = new AsyncCommand(() => LoadMoreData(), allowsMultipleExecutions: false);

            LoadedCommand = new AsyncCommand(() => LoadData(), allowsMultipleExecutions: false);

            //NavigateProductCommand = new DelegateCommand<ProcessorModel>(async (selectedDog) =>
            //{
            //    var navParam = new NavigationParameters { { nameof(selectedDog), selectedDog } };
            //    await navigationService.NavigateAsync(nameof(ProductPage), navParam);
            //});
        }

        private Task LoadData()
        {
            if (IsLoaded)
            {
                return Task.CompletedTask;
            }

            for (int i = 0; i < 128; i++)
            {
                ProductList.Add(i);
            }

            IsLoaded = true;
            return Task.CompletedTask;
        }

        private Task LoadMoreData()
        {
            if (!IsLoaded)
            {
                return Task.CompletedTask;
            }

            if (ProductList.Count >= 2048)
            {
                remainingItemsThreshold = -1;
                return Task.CompletedTask;
            }

            for (int i = 0; i < 64; i++)
            {
                ProductList.Add(i);
            }

            return Task.CompletedTask;
        }
    }
}