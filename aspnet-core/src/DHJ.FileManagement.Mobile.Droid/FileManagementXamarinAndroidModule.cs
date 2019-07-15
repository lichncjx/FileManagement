using Abp.Modules;
using Abp.Reflection.Extensions;

namespace DHJ.FileManagement
{
    [DependsOn(typeof(FileManagementXamarinSharedModule))]
    public class FileManagementXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FileManagementXamarinAndroidModule).GetAssembly());
        }
    }
}