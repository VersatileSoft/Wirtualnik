using System.Threading.Tasks;
using Wirtualnik.XF.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public class CustomLazyView<TView, TViewModel> : BaseLazyView where TView : View, new() where TViewModel : ViewModelBase
    {
        public override async ValueTask LoadViewAsync()
        {
            if (typeof(TViewModel) is null)
            {
                Content = new TView();
                SetIsLoaded(true);

                return;
            }

            // stupid way to get rid of smoll hangs 
            await Task.Delay(100);

            ViewModelBase? viewModel = App.GetViewModel<TViewModel>();
            Content = new TView { BindingContext = viewModel };

            SetIsLoaded(true);

            return;
        }
    }
}
