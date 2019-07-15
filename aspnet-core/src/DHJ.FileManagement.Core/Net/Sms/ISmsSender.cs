using System.Threading.Tasks;

namespace DHJ.FileManagement.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}