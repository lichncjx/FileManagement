using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Files.FileFeatures.Technologies.Manager
{
    public interface ITechnolohyInfoManager<T> : IFileFeatureManagerBase<T> where T : FileBase, IHasTechnologyInfo
        
    }
}