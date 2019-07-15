using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace DHJ.FileManagement
{
    [DependsOn(typeof(FileManagementClientModule), typeof(AbpAutoMapperModule))]
    public class FileManagementXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FileManagementXamarinSharedModule).GetAssembly());
        }
    }
}