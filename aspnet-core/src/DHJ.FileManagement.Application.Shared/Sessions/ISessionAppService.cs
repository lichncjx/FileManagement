using System.Threading.Tasks;
using Abp.Application.Services;
using DHJ.FileManagement.Sessions.Dto;

namespace DHJ.FileManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
