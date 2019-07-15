using DHJ.FileManagement.Editions;
using DHJ.FileManagement.MultiTenancy.Payments;

namespace DHJ.FileManagement.Web.Models.Payment
{
    public class CreatePaymentModel
    {
        public int EditionId { get; set; }

        public PaymentPeriodType? PaymentPeriodType { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}
