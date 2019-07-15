using System.Threading.Tasks;
using Abp.Application.Services;
using DHJ.FileManagement.Configuration.Host.Dto;

namespace DHJ.FileManagement.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
