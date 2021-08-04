using System.Drawing;

namespace Wirtualnik.XF.Services
{
    public interface IEnviroment
    {
        void SetSystemBarsColor(Color backgroundColor, bool isThisColorLight);
        void SetBackground(bool setSplashAsBackground, Color? backgroundColor);
    }
}