using System.Collections.Generic;
using System.Linq;
using DHJ.FileManagement.Files.FileFeatures.Changes;
using DHJ.FileManagement.Files.FileFeatures.Technologies;

namespace DHJ.FileManagement.Files.FileEntities.Drawings
{
    public class Drawing : FileBase, IHasDrawingNumber, IHasSection, IHasStage, IHasChange
    {
        public string DrawingNumber { get; set; }
        public int SectionInfoId { get; set; }
        public ProductStage ProductStage { get; set; }
        public IEnumerable<ChangeRecord> ChangeRecords { get; set; }
    }
}