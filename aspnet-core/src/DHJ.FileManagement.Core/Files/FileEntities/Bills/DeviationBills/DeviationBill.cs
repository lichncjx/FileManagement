using DHJ.FileManagement.Files.FileFeatures.Productions;
using DHJ.FileManagement.Files.FileFeatures.Productions.Model;
using DHJ.FileManagement.Files.FileFeatures.Technologies;
using DHJ.FileManagement.Files.FileFeatures.Technologies.Model;
using DHJ.FileManagement.Files.FileFeatures.Versions;

namespace DHJ.FileManagement.Files.FileEntities.Bills.DeviationBills
{
    /// <summary>
    /// 偏离单
    /// </summary>
    public class DeviationBill : BillBase, IHasTechnologyInfo, IHasProductionInfo, IHasVersion
    {
        public virtual int Version { get; set; }
        public virtual TechnologyInfo TechnologyInfo { get; set; }
        public virtual ProductionInfo ProductionInfo { get; set; }
    }
}
