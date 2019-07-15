using Abp.AspNetCore.Mvc.ViewComponents;

namespace DHJ.FileManagement.Web.Views
{
    public abstract class FileManagementViewComponent : AbpViewComponent
    {
        protected FileManagementViewComponent()
        {
            LocalizationSourceName = FileManagementConsts.LocalizationSourceName;
        }
    }
}