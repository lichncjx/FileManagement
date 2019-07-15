using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Web.Session;

namespace DHJ.FileManagement.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewComponent : FileManagementViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AccountLogoViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            return View(new AccountLogoViewModel(loginInfo));
        }
    }
}
