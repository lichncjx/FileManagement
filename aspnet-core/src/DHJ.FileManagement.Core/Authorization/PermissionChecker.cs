using Abp.Authorization;
using DHJ.FileManagement.Authorization.Roles;
using DHJ.FileManagement.Authorization.Users;

namespace DHJ.FileManagement.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
