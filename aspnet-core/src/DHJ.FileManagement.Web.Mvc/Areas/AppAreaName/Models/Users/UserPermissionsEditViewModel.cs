using Abp.AutoMapper;
using DHJ.FileManagement.Authorization.Users;
using DHJ.FileManagement.Authorization.Users.Dto;
using DHJ.FileManagement.Web.Areas.AppAreaName.Models.Common;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}