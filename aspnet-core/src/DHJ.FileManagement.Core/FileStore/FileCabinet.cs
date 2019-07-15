using System.Linq;

namespace DHJ.FileManagement.FileStore
{
    //文件柜
    public class FileCabinet : StoreBase
    {
        public StoreRoom Room { get; set; }

        public IQueryable<FileBox> Boxs { get; set; }
    }
}