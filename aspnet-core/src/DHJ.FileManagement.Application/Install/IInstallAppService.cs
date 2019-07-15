using System.Threading.Tasks;
using Abp.Application.Services;
using DHJ.FileManagement.Install.Dto;

namespace DHJ.FileManagement.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}