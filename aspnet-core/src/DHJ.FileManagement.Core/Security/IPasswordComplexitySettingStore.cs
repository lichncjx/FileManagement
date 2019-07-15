using System.Threading.Tasks;

namespace DHJ.FileManagement.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
