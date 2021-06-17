using Autofac;

namespace Wirtualnik.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(typeof(RepositoryModule).Assembly).AsImplementedInterfaces();
        }
    }
}