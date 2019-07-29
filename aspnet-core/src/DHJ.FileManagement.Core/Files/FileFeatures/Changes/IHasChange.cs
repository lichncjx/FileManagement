using System.Collections.Generic;
using System.Linq;

namespace DHJ.FileManagement.Files.FileFeatures.Changes
{
    public interface IHasChange
    {
        IEnumerable<ChangeRecord> ChangeRecords { get; set; }
    }
}