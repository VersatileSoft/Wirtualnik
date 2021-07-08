using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private bool isBusy;
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

        public ViewModelBase()
        {
            isBusy = true;
        }
    }
}