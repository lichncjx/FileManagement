using Abp.Modules;
using Abp.Reflection.Extensions;

namespace DHJ.FileManagement
{
    public class FileManagementClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FileManagementClientModule).GetAssembly());
        }
    }
}
