using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.ModelBaseInfos.Sections.Dto;

namespace DHJ.FileManagement.ModelBaseInfos.Models.Dto
{
    public class ModelInfoListDto : EntityDto
    {
        public string Name { get; set; }

        public List<SectionInfoListDto> SectionInfos { get; set; }
    }
}