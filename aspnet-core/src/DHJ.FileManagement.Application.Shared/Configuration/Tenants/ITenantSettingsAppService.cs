using System.Threading.Tasks;
using Abp.Application.Services;
using DHJ.FileManagement.Configuration.Tenants.Dto;

namespace DHJ.FileManagement.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
