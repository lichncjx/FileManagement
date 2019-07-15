using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.MultiTenancy.Accounting.Dto;

namespace DHJ.FileManagement.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
