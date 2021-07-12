using DryIoc;

namespace Wirtualnik.XF.Services.Implementations
{
    public class ServiceModule : IDryIocModule
    {
        public void Load(IRegistrator builder)
        {
            builder.Register<IAuthenticationService, AuthenticationService>();
            builder.Register<INavigationService, NavigationService>();
        }
    }
}
