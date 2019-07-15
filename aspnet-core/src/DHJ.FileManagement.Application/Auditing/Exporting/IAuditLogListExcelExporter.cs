using System.Collections.Generic;
using DHJ.FileManagement.Auditing.Dto;
using DHJ.FileManagement.Dto;

namespace DHJ.FileManagement.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
