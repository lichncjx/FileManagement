using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Authorization.Permissions.Dto;

namespace DHJ.FileManagement.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}