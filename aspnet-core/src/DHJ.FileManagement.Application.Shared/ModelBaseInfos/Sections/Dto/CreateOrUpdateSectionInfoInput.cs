namespace DHJ.FileManagement.ModelBaseInfos.Sections.Dto
{
    public class CreateOrUpdateSectionInfoInput
    {
        public int ModelInfoId { get; set; }

        public SectionInfoEditDto SectionInfo { get; set; }
    }
}