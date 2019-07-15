using Abp.AutoMapper;
using DHJ.FileManagement.Editions;
using DHJ.FileManagement.MultiTenancy.Payments.Dto;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}