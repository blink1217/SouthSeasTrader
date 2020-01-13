using SouthSeaTrader.Shared;
using System.Threading.Tasks;

namespace SouthSeaTrader.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
