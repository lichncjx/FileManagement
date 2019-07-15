using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace DHJ.FileManagement.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=FileManagement; Trusted_Connection=True;");
            csb["Database"].ShouldBe("FileManagement");
        }
    }
}
