using DHJ.FileManagement.EntityFrameworkCore;

namespace DHJ.FileManagement.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly FileManagementDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(FileManagementDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
