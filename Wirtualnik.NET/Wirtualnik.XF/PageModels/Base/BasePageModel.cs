using Wirtualnik.XF.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.PageModels.Base
{
    public class BasePageModel : ObservableObject
    {
        private readonly INavigationService navigationService;

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public AsyncCommand GoBackCommand { get; }

        public BasePageModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            GoBackCommand = new AsyncCommand(async () => await this.navigationService.GoBackAsync().ConfigureAwait(false), allowsMultipleExecutions: false);
        }
    }
}