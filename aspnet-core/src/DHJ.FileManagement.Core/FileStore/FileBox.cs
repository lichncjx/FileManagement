using System.Collections.Generic;
using System.Linq;

namespace DHJ.FileManagement.FileStore
{
    public class FileBox : StoreBase
    {
        public FileCabinet Cabinet { get; set; }

        public List<int> FileId { get; set; }
    }
}