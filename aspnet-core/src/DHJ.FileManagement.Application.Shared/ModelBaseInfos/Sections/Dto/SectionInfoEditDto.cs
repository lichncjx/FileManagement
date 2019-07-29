﻿using Abp.Application.Services.Dto;
using DHJ.FileManagement.Files;

namespace DHJ.FileManagement.ModelBaseInfos.Sections.Dto
{
    public class SectionInfoEditDto : NullableIdDto
    {
        public string Name { get; set; }

        public string DrawingNumber { get; set; }

        public ProductStage ProductStage { get; set; }
    }
}