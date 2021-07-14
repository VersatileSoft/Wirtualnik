using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wirtualnik.XF.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TPage>() where TPage : Page, new();
        Task PopAsync();

        void SetMainPage<TPage>() where TPage : Page, new();
    }
}