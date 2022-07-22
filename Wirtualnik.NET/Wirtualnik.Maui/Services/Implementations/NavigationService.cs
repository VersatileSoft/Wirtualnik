namespace Wirtualnik.Maui.Services.Implementations;

public class NavigationService : INavigationService
{
    public Task NavigateToAsync<TPage>() where TPage : Page, new()
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
            await App.Current.MainPage.Navigation.PushAsync(new TPage())
        );
    }

    public Task NavigateToAsync(Type? pageType)
    {
        if (pageType is null)
        {
            return Task.CompletedTask;
        }

        return MainThread.InvokeOnMainThreadAsync(async () =>
            await App.Current.MainPage.Navigation.PushAsync((Page)Activator.CreateInstance(pageType))
        );
    }

    public Task NavigateToAsModalAsync<TPage>() where TPage : Page, new()
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
            await App.Current.MainPage.Navigation.PushModalAsync(new TPage())
        );
    }

    public Task NavigateToAsModalAsync(Type? pageType)
    {
        if (pageType is null)
        {
            return Task.CompletedTask;
        }

        return MainThread.InvokeOnMainThreadAsync(async () =>
            await App.Current.MainPage.Navigation.PushModalAsync((Page)Activator.CreateInstance(pageType))
        );
    }

    public Task GoBackAsync()
    {
        if (IsModal())
        {
            return MainThread.InvokeOnMainThreadAsync(async () =>
                await App.Current.MainPage.Navigation.PopModalAsync()
            );
        }

        return MainThread.InvokeOnMainThreadAsync(async () =>
            await App.Current.MainPage.Navigation.PopAsync()
        );
    }

    public void SetMainPage<TPage>() where TPage : Page, new()
    {
        MainThread.BeginInvokeOnMainThread(() =>
            App.Current.MainPage = new NavigationPage(new TPage())
        );
    }

    private bool IsModal()
    {
        return App.Current.MainPage.Navigation.ModalStack.Count > 0;
    }
}