using DHJ.FileManagement.Editions;
using DHJ.FileManagement.Editions.Dto;
using DHJ.FileManagement.Security;
using DHJ.FileManagement.MultiTenancy.Payments;
using DHJ.FileManagement.MultiTenancy.Payments.Dto;

namespace DHJ.FileManagement.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType? Gateway { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public bool ShowPaymentExpireNotification()
        {
            return !string.IsNullOrEmpty(PaymentId);
        }
    }
}
