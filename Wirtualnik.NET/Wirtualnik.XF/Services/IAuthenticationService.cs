using System.Threading.Tasks;

namespace Wirtualnik.XF.Services
{
    public interface IAuthenticationService
    {
        Task<bool> SignInAsync(string? scheme);
    }
}