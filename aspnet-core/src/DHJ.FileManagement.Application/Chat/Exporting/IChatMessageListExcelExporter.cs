using System.Collections.Generic;
using DHJ.FileManagement.Chat.Dto;
using DHJ.FileManagement.Dto;

namespace DHJ.FileManagement.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}
