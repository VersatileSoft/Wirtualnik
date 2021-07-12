using Wirtualnik.XF.ViewModels;
using Xamarin.Forms;

namespace Wirtualnik.XF.Views
{
    public partial class ProductListPage : ContentView
    {
        public ProductListPage()
        {
            InitializeComponent();
        }

        private async void LifecycleEffect_Loaded(object sender, System.EventArgs e)
        {
            if (BindingContext is not ProductListPageViewModel viewModel)
            {
                return;
            }

            await viewModel.LoadedCommand.ExecuteAsync().ConfigureAwait(false);
        }
    }
}