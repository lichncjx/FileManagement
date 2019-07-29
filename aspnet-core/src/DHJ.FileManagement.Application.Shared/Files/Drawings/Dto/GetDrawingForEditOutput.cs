using System.Collections.Generic;
using DHJ.FileManagement.ModelBaseInfos.Sections.Dto;

namespace DHJ.FileManagement.Files.Drawings.Dto
{
    public class GetDrawingForEditOutput
    {
        public List<SectionInfoListDto> SectionInfos { get; set; }

        public DrawingEditDto Drawing { get; set; }
    }
}