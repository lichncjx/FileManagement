using System;
using DHJ.FileManagement.Core;
using DHJ.FileManagement.Core.Dependency;
using DHJ.FileManagement.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DHJ.FileManagement.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}