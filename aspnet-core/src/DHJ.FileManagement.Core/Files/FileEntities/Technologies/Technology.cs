using DHJ.FileManagement.Files.FileFeatures.Technologies;
using DHJ.FileManagement.Files.FileFeatures.Technologies.Model;
using DHJ.FileManagement.Files.FileFeatures.Versions;

namespace DHJ.FileManagement.Files.FileEntities.Technologies
{
    public class Technology : FileBase,IHasTechnologyInfo,IHasVersion
    {
        public virtual int Version { get; set; }
        public virtual TechnologyInfo TechnologyInfo { get; set; }
    }
}