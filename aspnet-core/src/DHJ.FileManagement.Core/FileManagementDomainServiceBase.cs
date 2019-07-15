using Abp.Domain.Services;

namespace DHJ.FileManagement
{
    public abstract class FileManagementDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected FileManagementDomainServiceBase()
        {
            LocalizationSourceName = FileManagementConsts.LocalizationSourceName;
        }
    }
}
