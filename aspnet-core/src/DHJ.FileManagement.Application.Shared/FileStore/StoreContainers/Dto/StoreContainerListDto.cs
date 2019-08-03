using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace DHJ.FileManagement.FileStore.StoreContainers.Dto
{
    public class StoreContainerListDto : EntityDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Describe { get; set; }

        public ICollection<string> Administrators { get; set; }
    }
}