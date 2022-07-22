using Color = System.Drawing.Color;

namespace Wirtualnik.Maui.Services;

public interface IEnviroment
{
    void SetSystemBarsColor(Color backgroundColor, bool isThisColorLight);
    void SetBackground(bool setSplashAsBackground, Color? backgroundColor);
}