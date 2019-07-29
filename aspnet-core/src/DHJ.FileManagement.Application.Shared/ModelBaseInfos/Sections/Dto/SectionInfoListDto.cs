using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Files;

namespace DHJ.FileManagement.ModelBaseInfos.Sections.Dto
{
    public class SectionInfoListDto : EntityDto
    {
        /// <summary>
        /// 部段名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部段图号
        /// </summary>
        public string DrawingNumber { get; set; }

        /// <summary>
        /// 所属阶段
        /// </summary>
        public ProductStage ProductStage { get; set; }
    }
}
