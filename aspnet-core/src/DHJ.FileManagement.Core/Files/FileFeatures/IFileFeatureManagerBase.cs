using System.Collections.Generic;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Files.FileFeatures
{
    public interface IFileFeatureManagerBase<T> where T : FileBase
    {
        IEnumerable<T> GetObjByCurrentFeature(T currentObj);

        IEnumerable<T> GetObjByCurrentFeature(IEnumerable<T> objCollection, T currentObj);
    }
}