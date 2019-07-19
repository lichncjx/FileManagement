using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Files.FileFeatures.Technologies.Manager
{
    public class TechnolohyInfoManager<T> : FileFeatureManagerBase<T>, ITechnolohyInfoManager<T> where T : FileBase, IHasTechnologyInfo
    {
        public TechnolohyInfoManager(IRepository<T> tRepository) : base(tRepository)
        {
        }

        public override IEnumerable<T> GetObjByCurrentFeature(T currentObj)
        {
            return _tRepository.GetAll().Where(c => c.TechnologyInfo == currentObj.TechnologyInfo);
        }

        public override IEnumerable<T> GetObjByCurrentFeature(IEnumerable<T> objCollection, T currentObj)
        {
            return objCollection.Where(c => c.TechnologyInfo == currentObj.TechnologyInfo);
        }
    }
}