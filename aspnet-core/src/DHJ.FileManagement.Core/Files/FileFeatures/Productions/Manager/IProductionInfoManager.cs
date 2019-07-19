using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Files.FileFeatures.Productions.Manager
{
    public interface IProductionInfoManager<T> : IFileFeatureManagerBase<T> where  T : FileBase, IHasProductionInfo
    {
        
    }
}