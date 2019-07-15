using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DHJ.FileManagement.Configuration;
using DHJ.FileManagement.Web;

namespace DHJ.FileManagement.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FileManagementDbContextFactory : IDesignTimeDbContextFactory<FileManagementDbContext>
    {
        public FileManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FileManagementDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            FileManagementDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FileManagementConsts.ConnectionStringName));

            return new FileManagementDbContext(builder.Options);
        }
    }
}