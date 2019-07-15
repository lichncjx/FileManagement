using System.Threading.Tasks;
using Abp.Application.Services;

namespace DHJ.FileManagement.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);
    }
}
