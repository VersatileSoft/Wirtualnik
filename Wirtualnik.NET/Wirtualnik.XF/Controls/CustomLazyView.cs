using DryIoc;
using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public class CustomLazyView<TView> : BaseLazyView where TView : View, new()
    {
        private readonly Type? viewModelType;

        public CustomLazyView(Type? viewModel)
        {
            this.viewModelType = viewModel;
        }

        public override ValueTask LoadViewAsync()
        {
            if (this.viewModelType is null)
            {
                Content = new TView();

                SetIsLoaded(true);
                return new ValueTask(Task.FromResult(true));
            }

            ObservableObject? viewModel = App.Container.Resolve(this.viewModelType) as ObservableObject;
            Content = new TView { BindingContext = viewModel };

            SetIsLoaded(true);
            return new ValueTask(Task.FromResult(true));
        }
    }
}
