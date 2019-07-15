using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.FileStore
{
    public class StoreBase : FullAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
    }
}