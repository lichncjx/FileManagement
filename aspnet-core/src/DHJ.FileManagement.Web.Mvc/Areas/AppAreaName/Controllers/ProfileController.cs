using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Configuration;
using Abp.MultiTenancy;
using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Authorization.Users.Profile;
using DHJ.FileManagement.Configuration;
using DHJ.FileManagement.Timing;
using DHJ.FileManagement.Timing.Dto;
using DHJ.FileManagement.Web.Areas.AppAreaName.Models.Profile;
using DHJ.FileManagement.Web.Controllers;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize]
    public class ProfileController : FileManagementControllerBase
    {
        private readonly IProfileAppService _profileAppService;
        private readonly ITimingAppService _timingAppService;
        private readonly ITenantCache _tenantCache;

        public ProfileController(
            IProfileAppService profileAppService,
            ITimingAppService timingAppService, 
            ITenantCache tenantCache)
        {
            _profileAppService = profileAppService;
            _timingAppService = timingAppService;
            _tenantCache = tenantCache;
        }

        public async Task<PartialViewResult> MySettingsModal()
        {
            var output = await _profileAppService.GetCurrentUserProfileForEdit();
            var timezoneItems = await _timingAppService.GetTimezoneComboboxItems(new GetTimezoneComboboxItemsInput
            {
                DefaultTimezoneScope = SettingScopes.User,
                SelectedTimezoneId = output.Timezone
            });
           

            var viewModel = new MySettingsViewModel(output)
            {
                TimezoneItems = timezoneItems,
                SmsVerificationEnabled = await SettingManager.GetSettingValueAsync<bool>(AppSettings.UserManagement.SmsVerificationEnabled)
            };

            return PartialView("_MySettingsModal", viewModel);
        }

        public PartialViewResult ChangePictureModal()
        {
            return PartialView("_ChangePictureModal");
        }

        public PartialViewResult ChangePasswordModal()
        {
            return PartialView("_ChangePasswordModal");
        }

        

        public PartialViewResult SmsVerificationModal()
        {
            return PartialView("_SmsVerificationModal");
        }


        public PartialViewResult LinkedAccountsModal()
        {
            return PartialView("_LinkedAccountsModal");
        }

        public PartialViewResult LinkAccountModal()
        {
            ViewBag.TenancyName = GetTenancyNameOrNull();
            return PartialView("_LinkAccountModal");
        }

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }
    }
}