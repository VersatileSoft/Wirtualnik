using TinyMvvm;

namespace Wirtualnik.Maui.ViewModels.Base;

public class BaseViewModel : ViewModelBase
{
    public BaseViewModel()
    {
        IsBusy = true;
    }
}