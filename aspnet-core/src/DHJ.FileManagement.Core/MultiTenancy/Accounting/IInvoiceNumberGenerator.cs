using System.Threading.Tasks;
using Abp.Dependency;

namespace DHJ.FileManagement.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}