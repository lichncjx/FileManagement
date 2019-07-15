using Microsoft.Extensions.Configuration;

namespace DHJ.FileManagement.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
