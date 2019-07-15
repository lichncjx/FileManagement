using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DHJ.FileManagement.EntityFrameworkCore
{
    public static class FileManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FileManagementDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FileManagementDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}