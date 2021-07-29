using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace Wirtualnik.Uno.Admin.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new Wirtualnik.Uno.Admin.App(), args);
            host.Run();
        }
    }
}
