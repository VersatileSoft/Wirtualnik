using DryIoc;

namespace Wirtualnik.XF.Services
{
    public interface IDryIocModule
    {
        void Load(IRegistrator builder);
    }
}
