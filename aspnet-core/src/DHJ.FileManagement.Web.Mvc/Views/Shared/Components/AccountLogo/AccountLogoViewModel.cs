using DHJ.FileManagement.Sessions.Dto;

namespace DHJ.FileManagement.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; }

        public AccountLogoViewModel(GetCurrentLoginInformationsOutput loginInformations)
        {
            LoginInformations = loginInformations;
        }

        public string GetLogoUrl(string appPath)
        {
            if (LoginInformations.Tenant?.LogoId == null)
            {
                return appPath + "Common/Images/app-logo-on-light.svg";
            }

            return appPath + "TenantCustomization/GetLogo?id=" + LoginInformations.Tenant.LogoId;
        }
    }
}