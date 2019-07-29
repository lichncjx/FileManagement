using Abp.Application.Services.Dto;

namespace DHJ.FileManagement.Files.Drawings.Dto
{
    public class DrawingEditDto : NullableIdDto
    {
        public string FileName { get; set; }

        public string FileNumber { get; set; }

        public string DrawingNumber { get; set; }

        public int SectionInfoId { get; set; }
    }
}