using System.Threading.Tasks;
using Abp.Application.Services;
using DHJ.FileManagement.Editions.Dto;
using DHJ.FileManagement.MultiTenancy.Dto;

namespace DHJ.FileManagement.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}