using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace DHJ.FileManagement.FileStore.StoreContainers.Dto
{
    public class StoreContainerEditDto : NullableIdDto
    {
        public string Name { get; set; }

        public string Describe { get; set; }

        public ICollection<long> AdministratorIds { get; set; }
    }
}
