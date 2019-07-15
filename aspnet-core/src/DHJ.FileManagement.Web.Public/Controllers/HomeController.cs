using Microsoft.AspNetCore.Mvc;
using DHJ.FileManagement.Web.Controllers;

namespace DHJ.FileManagement.Web.Public.Controllers
{
    public class HomeController : FileManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}