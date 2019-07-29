using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.FileStore
{
    public class StoreContainer : FullAuditedEntity
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

        public IEnumerable<FileStoreInfo> FileStoreInfos { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public IEnumerable<int> AdministratorIds { get; set; }
    }
}