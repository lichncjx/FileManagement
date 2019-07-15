using System.Threading.Tasks;
using DHJ.FileManagement.ApiClient.Models;

namespace DHJ.FileManagement.ApiClient
{
    public interface IAccessTokenManager
    {
        Task<string> GetAccessTokenAsync();
         
        Task<AbpAuthenticateResultModel> LoginAsync();

        void Logout();

        bool IsUserLoggedIn { get; }
    }
}