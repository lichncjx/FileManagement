using DHJ.FileManagement.Files.FileFeatures.Technologies;
using DHJ.FileManagement.Files.FileFeatures.Technologies.Model;

namespace DHJ.FileManagement.Files.FileEntities.Drawings
{
    public class Drawing : FileBase,IHasTechnologyInfo
    {
        public virtual TechnologyInfo TechnologyInfo { get; set; }
    }
}