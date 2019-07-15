using System.Collections.Generic;
using Abp.Domain.Repositories;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Files.FileFeatures
{
    public abstract class FileFeatureManagerBase<T> : IFileFeatureManagerBase<T> where T : FileBase
    {
        protected IRepository<T> _tRepository;
        public FileFeatureManagerBase(IRepository<T> tRepository)
        {
            _tRepository = tRepository;
        }

        public abstract IEnumerable<T> GetObjByCurrentFeature(T currentObj);
        public abstract IEnumerable<T> GetObjByCurrentFeature(IEnumerable<T> objCollection, T currentObj);
    }
}