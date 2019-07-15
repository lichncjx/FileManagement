using Abp.AspNetZeroCore;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using DHJ.FileManagement.Configuration;
using DHJ.FileManagement.EntityFrameworkCore;

namespace DHJ.FileManagement.Web.Public.Startup
{
    [DependsOn(
        typeof(FileManagementWebCoreModule)
    )]
    public class FileManagementWebFrontEndModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FileManagementWebFrontEndModule(IHostingEnvironment env, FileManagementEntityFrameworkCoreModule FileManagementEntityFrameworkCoreModule)
        {
            _appConfiguration = env.GetAppConfiguration();
            FileManagementEntityFrameworkCoreModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = _appConfiguration["App:WebSiteRootAddress"] ?? "http://localhost:45776/";
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];

            //Changed AntiForgery token/cookie names to not conflict to the main application while redirections.
            Configuration.Modules.AbpWebCommon().AntiForgery.TokenCookieName = "Public-XSRF-TOKEN";
            Configuration.Modules.AbpWebCommon().AntiForgery.TokenHeaderName = "Public-X-XSRF-TOKEN";

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.Navigation.Providers.Add<FrontEndNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FileManagementWebFrontEndModule).GetAssembly());
        }
    }
}
