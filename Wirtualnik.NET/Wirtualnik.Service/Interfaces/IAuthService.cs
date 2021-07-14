using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Auth;

namespace Wirtualnik.Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> ExternalLoginAsync(AuthenticateResult auth);

        Task<LoginResult> LoginAsync(LoginModel model);
    }
}