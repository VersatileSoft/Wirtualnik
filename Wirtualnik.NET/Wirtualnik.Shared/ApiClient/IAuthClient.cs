using Refit;
using System.Threading.Tasks;
using Wirtualnik.Shared.Models.Auth;

namespace Wirtualnik.Shared.ApiClient
{
    public interface IAuthClient
    {
        [Post("/login")]
        public Task<ApiResponse<LoginResult>> LoginAsync(LoginModel model);
    }
}
