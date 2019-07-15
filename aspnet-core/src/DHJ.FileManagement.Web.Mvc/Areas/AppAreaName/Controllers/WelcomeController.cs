using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Web.Controllers;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize]
    public class WelcomeController : FileManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}