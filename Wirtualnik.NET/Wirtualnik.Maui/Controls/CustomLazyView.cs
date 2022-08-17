using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;

namespace Wirtualnik.Maui.Controls
{
    public class CustomLazyView<TView, TViewModel> : BaseLazyView where TView : View, new() where TViewModel : ObservableObject
    {
        public override ValueTask LoadViewAsync()
        {
            if (typeof(TViewModel) is null)
            {
                Content = new TView();
                SetIsLoaded(true);

                return default;
            }

            // stupid way to get rid of smoll hangs 
            //await Task.Delay(100);

            ObservableObject? viewModel = App.GetPageViewModel<TViewModel>();
            Content = new TView { BindingContext = viewModel };

            SetIsLoaded(true);
            return default;
        }
    }
}