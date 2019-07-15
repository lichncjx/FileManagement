using Abp.AutoMapper;
using DHJ.FileManagement.Authorization.Roles.Dto;
using DHJ.FileManagement.Web.Areas.AppAreaName.Models.Common;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}