using TinyMvvm;

namespace Wirtualnik.Maui.ViewModels.Base;

public class BaseViewModel : TinyViewModel
{
    public BaseViewModel()
    {
        IsBusy = true;
    }
}