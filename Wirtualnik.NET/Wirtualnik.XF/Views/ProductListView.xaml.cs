using Wirtualnik.XF.ViewModels;
using Xamarin.Forms;

namespace Wirtualnik.XF.Views
{
    public partial class ProductListView : ContentView
    {
        public ProductListView()
        {
            InitializeComponent();
        }

        private async void LifecycleEffect_Loaded(object sender, System.EventArgs e)
        {
            if (BindingContext is not ProductListViewModel viewModel)
            {
                return;
            }

            if (viewModel.IsLoaded)
            {
                return;
            }

            await viewModel.LoadedCommand.ExecuteAsync().ConfigureAwait(false);
        }
    }
}