
using System.Linq;
using DHJ.FileManagement.Files.FileFeatures.Changes;
using DHJ.FileManagement.Files.FileFeatures.Technologies;

namespace DHJ.FileManagement.Files.FileEntities.Technologies
{
    public class Technology : FileBase, IHasDrawingNumber, IHasStage, IHasChange
    {
        public string DrawingNumber { get; set; }
        public ProductStage ProductStage { get; set; }
        public IQueryable<ChangeRecord> ChangeRecords { get; set; }
    }
}