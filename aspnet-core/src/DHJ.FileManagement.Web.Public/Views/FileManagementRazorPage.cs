using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace DHJ.FileManagement.Web.Public.Views
{
    public abstract class FileManagementRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected FileManagementRazorPage()
        {
            LocalizationSourceName = FileManagementConsts.LocalizationSourceName;
        }
    }
}
