using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Authorization.Permissions.Dto;

namespace DHJ.FileManagement.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
