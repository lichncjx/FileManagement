using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.FileStore
{
    public class FileStoreInfo : FullAuditedEntity
    {
        public int FileId { get; set; }

        public int FileContainerId { get; set; }

        public string FileType { get; set; }

        public StoreState StoreState { get; set; }
    }
}