using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace DHJ.FileManagement.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
