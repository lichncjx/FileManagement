using System.Threading.Tasks;
using DHJ.FileManagement.Sessions.Dto;

namespace DHJ.FileManagement.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
