using System.Collections.Generic;
using DHJ.FileManagement.Authorization.Users.Dto;
using DHJ.FileManagement.Dto;

namespace DHJ.FileManagement.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}