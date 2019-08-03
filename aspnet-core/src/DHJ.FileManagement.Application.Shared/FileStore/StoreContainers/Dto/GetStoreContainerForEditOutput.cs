using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Authorization.Users.Dto;

namespace DHJ.FileManagement.FileStore.StoreContainers.Dto
{
    public class GetStoreContainerForEditOutput
    {
        public ListResultDto<UserListDto> Users { get; set; }

        public StoreContainerEditDto StoreContainer { get; set; }
    }
}