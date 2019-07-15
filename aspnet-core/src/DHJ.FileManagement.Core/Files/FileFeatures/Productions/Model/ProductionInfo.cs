using Abp.Domain.Values;

namespace DHJ.FileManagement.Files.FileFeatures.Productions.Model
{
    public class ProductionInfo : ValueObject<ProductionInfo>
    {
        string Launch { get; set; }
    }
}