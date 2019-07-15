using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Authorization;
using DHJ.FileManagement.Web.Controllers;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : FileManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}