using System.Threading.Tasks;

namespace Wirtualnik.Maui.Services;

public interface IAuthenticationService
{
    Task<bool> SignInAsync(string? scheme);
}