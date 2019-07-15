using System.Collections.Generic;
using DHJ.FileManagement.Authorization.Permissions.Dto;

namespace DHJ.FileManagement.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}