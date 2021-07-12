using Refit;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Auth;

namespace Wirtualnik.Shared.ApliClient
{
    public interface IAuthClient
    {
        [Post("/login")]
        public Task<LoginResult> LoginAsync(LoginModel model);
    }
}
