using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using DHJ.FileManagement.Configuration;

namespace DHJ.FileManagement.Tests.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(FileManagementTestModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
