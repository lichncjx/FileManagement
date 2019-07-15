using Abp.AspNetZeroCore;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using DHJ.FileManagement.Configuration;
using DHJ.FileManagement.EntityFrameworkCore;
using DHJ.FileManagement.Migrator.DependencyInjection;

namespace DHJ.FileManagement.Migrator
{
    [DependsOn(typeof(FileManagementEntityFrameworkCoreModule))]
    public class FileManagementMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FileManagementMigratorModule(FileManagementEntityFrameworkCoreModule FileManagementEntityFrameworkCoreModule)
        {
            FileManagementEntityFrameworkCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(FileManagementMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                FileManagementConsts.ConnectionStringName
                );
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FileManagementMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}