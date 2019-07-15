using Abp.Domain.Values;

namespace DHJ.FileManagement.Files.FileFeatures.Technologies.Model
{
    public class TechnologyInfo : ValueObject<TechnologyInfo>
    {
        int ModelId { get; set; }

        string DrawingNum { get; set; }
    }
}