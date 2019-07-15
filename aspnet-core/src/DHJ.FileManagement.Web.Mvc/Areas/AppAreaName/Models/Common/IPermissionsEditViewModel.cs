using System.Collections.Generic;
using DHJ.FileManagement.Authorization.Permissions.Dto;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}