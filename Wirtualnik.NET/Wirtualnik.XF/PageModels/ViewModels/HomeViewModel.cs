using System.Threading.Tasks;
using Wirtualnik.Extensions;
using Wirtualnik.XF.PageModels.Base;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public int remainingItemsThreshold { get; set; } = 1;
        public bool IsLoaded { get; set; }

        public SafeObservableCollection<int> ProductList { get; set; }
        public AsyncCommand LoadMoreItemsCommand { get; set; }

        public HomeViewModel()
        {
            ProductList = new SafeObservableCollection<int>();

            LoadMoreItemsCommand = new AsyncCommand(() => LoadMoreData(), allowsMultipleExecutions: false);
        }

        public override Task OnFirstAppear()
        {
            LoadData();

            return base.OnFirstAppear();
        }

        private Task LoadData()
        {
            if (IsLoaded)
            {
                return Task.CompletedTask;
            }

            for (int i = 0; i < 6; i++)
            {
                //await Task.Delay(75 / (i+1));
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

            for (int i = 0; i < 12; i++)
            {
                ProductList.Add(i);
            }

            return Task.CompletedTask;
        }
    }
}
