using DHJ.FileManagement.Files.FileFeatures.Productions.Model;

namespace DHJ.FileManagement.Files.FileFeatures.Productions
{
    public interface IHasProductionInfo
    {
        ProductionInfo ProductionInfo { get; set; }
    }
}