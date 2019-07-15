using DHJ.FileManagement.Auditing;
using Shouldly;
using Xunit;

namespace DHJ.FileManagement.Tests.Auditing
{
    public class NamespaceStripper_Tests: AppTestBase
    {
        private readonly INamespaceStripper _namespaceStripper;

        public NamespaceStripper_Tests()
        {
            _namespaceStripper = Resolve<INamespaceStripper>();
        }

        [Fact]
        public void Should_Stripe_Namespace()
        {
            var controllerName = _namespaceStripper.StripNameSpace("DHJ.FileManagement.Web.Controllers.HomeController");
            controllerName.ShouldBe("HomeController");
        }

        [Theory]
        [InlineData("DHJ.FileManagement.Auditing.GenericEntityService`1[[DHJ.FileManagement.Storage.BinaryObject, DHJ.FileManagement.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null]]", "GenericEntityService<BinaryObject>")]
        [InlineData("CompanyName.ProductName.Services.Base.EntityService`6[[CompanyName.ProductName.Entity.Book, CompanyName.ProductName.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[CompanyName.ProductName.Services.Dto.Book.CreateInput, N...", "EntityService<Book, CreateInput>")]
        [InlineData("DHJ.FileManagement.Auditing.XEntityService`1[DHJ.FileManagement.Auditing.AService`5[[DHJ.FileManagement.Storage.BinaryObject, DHJ.FileManagement.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[DHJ.FileManagement.Storage.TestObject, DHJ.FileManagement.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],]]", "XEntityService<AService<BinaryObject, TestObject>>")]
        public void Should_Stripe_Generic_Namespace(string serviceName, string result)
        {
            var genericServiceName = _namespaceStripper.StripNameSpace(serviceName);
            genericServiceName.ShouldBe(result);
        }
    }
}
