using Bimber.Extensions;
using Prism.Navigation;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.ViewModels
{
    public class ProductListPageViewModel : ViewModelBase
    {
        public int remainingItemsThreshold { get; set; } = 1;
        public bool IsLoaded { get; set; }

        public SafeObservableCollection<ProcessorModel> ProductList { get; set; }
        //public DelegateCommand<ProcessorModel> NavigateProductCommand { get; set; }
        public AsyncCommand LoadMoreItemsCommand { get; set; }
        public ProductListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ProductList = new SafeObservableCollection<ProcessorModel>();

            LoadMoreItemsCommand = new AsyncCommand(() => LoadMoreData(), allowsMultipleExecutions: false);

            //NavigateProductCommand = new DelegateCommand<ProcessorModel>(async (selectedDog) =>
            //{
            //    var navParam = new NavigationParameters { { nameof(selectedDog), selectedDog } };
            //    await navigationService.NavigateAsync(nameof(ProductPage), navParam);
            //});
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            LoadData();
        }

        private void LoadData()
        {
            if (IsLoaded)
            {
                return;
            }

            for (int i = 0; i < 128; i++)
            {
                ProcessorModel processorModel = new ProcessorModel();
                ProductList.Add(processorModel);
            }

            RaisePropertyChanged("ProductList");
            IsLoaded = true;
        }

        private Task LoadMoreData()
        {
            if (ProductList.Count >= 2048)
            {
                remainingItemsThreshold = -1;
                return Task.CompletedTask;
            }

            for (int i = 0; i < 64; i++)
            {
                ProcessorModel processorModel = new ProcessorModel();
                ProductList.Add(processorModel);
            }

            return Task.CompletedTask;
        }
    }
}