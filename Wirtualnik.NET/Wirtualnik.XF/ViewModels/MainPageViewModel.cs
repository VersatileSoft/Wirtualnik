using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wirtualnik.XF.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public List<int> ProductList { get; set; }
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ProductList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await LoadDataAsync().ConfigureAwait(false);
        }

        private async Task LoadDataAsync()
        {
            //var colorPalette = await CrossColorThief.Current.GetPalette(ImageSource.FromUri(new System.Uri("https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"))).ConfigureAwait(false);

            //var color1 = colorPalette[0];
            //var color2 = colorPalette[1];
            //var color3 = colorPalette[2];
            //var color4 = colorPalette[3];
            //var color5 = colorPalette[4];
            //var color6 = colorPalette[5];
            //var color7 = colorPalette[6];
            //var coasdlor7 = colorPalette[6];
        }
    }
}