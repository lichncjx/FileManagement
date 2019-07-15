using Abp.AspNetCore.Mvc.Authorization;
using DHJ.FileManagement.Storage;

namespace DHJ.FileManagement.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}