using System.ComponentModel.DataAnnotations;

namespace DHJ.FileManagement.ModelBaseInfos.Sections.Dto
{
    public class CreateOrUpdateSectionInfoInput
    {
        [Required]
        public int ModelInfoId { get; set; }

        public SectionInfoEditDto SectionInfo { get; set; }
    }
}