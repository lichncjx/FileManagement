using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.FileStore
{
    public class FileStoreInfo : FullAuditedEntity
    {
        public int FileId { get; set; }

        public StoreState StoreState { get; set; }

        public FileBox FileBox { get; set; }
    }
}