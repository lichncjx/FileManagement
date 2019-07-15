using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace DHJ.FileManagement.Web.Controllers
{
    public class HomeController : FileManagementControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
