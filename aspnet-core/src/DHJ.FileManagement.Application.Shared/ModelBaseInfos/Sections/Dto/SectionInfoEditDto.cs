using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Files;

namespace DHJ.FileManagement.ModelBaseInfos.Sections.Dto
{
    public class SectionInfoEditDto : NullableIdDto
    {
        [Required]
        public string Name { get; set; }

        public string DrawingNumber { get; set; }

        [Required]
        public ProductStage ProductStage { get; set; }
    }
}