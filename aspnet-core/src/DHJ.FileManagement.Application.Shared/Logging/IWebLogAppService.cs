using Abp.Application.Services;
using DHJ.FileManagement.Dto;
using DHJ.FileManagement.Logging.Dto;

namespace DHJ.FileManagement.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
