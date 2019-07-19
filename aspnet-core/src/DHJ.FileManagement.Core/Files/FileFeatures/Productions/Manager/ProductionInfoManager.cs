using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Files.FileFeatures.Productions.Manager
{
    public class ProductionInfoManager<T> : FileFeatureManagerBase<T>,IProductionInfoManager<T> where T : FileBase, IHasProductionInfo
    {
        public ProductionInfoManager(IRepository<T> tRepository) : base(tRepository)
        {

        }

        public override IEnumerable<T> GetObjByCurrentFeature(T currentObj)
        {
            return _tRepository.GetAll().Where(c => c.ProductionInfo == currentObj.ProductionInfo);
        }

        public override IEnumerable<T> GetObjByCurrentFeature(IEnumerable<T> objCollection, T currentObj)
        {
            return objCollection.Where(c => c.ProductionInfo == currentObj.ProductionInfo);
        }
    }
}