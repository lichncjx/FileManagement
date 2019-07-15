using System.Collections.Generic;
using Abp.Domain.Repositories;
using Abp.UI;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Files.FileFeatures.Versions.Manager
{
    public class VersionManager<T> : FileFeatureManagerBase<T> where T : FileBase,IHasVersion
    {
        public VersionManager(IRepository<T> tRepository) : base(tRepository)
        {
        }

        public override IEnumerable<T> GetObjByCurrentFeature(T currentObj)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<T> GetObjByCurrentFeature(IEnumerable<T> objCollection, T currentObj)
        {
            throw new System.NotImplementedException();
        }


    }
}