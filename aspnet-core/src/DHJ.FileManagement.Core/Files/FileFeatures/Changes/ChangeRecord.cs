using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.Files.FileFeatures.Changes
{
    public class ChangeRecord : FullAuditedEntity
    {
        /// <summary>
        /// 更改单Id
        /// </summary>
        public int ChangeBillId { get; set; }

        /// <summary>
        /// 原文件Id
        /// </summary>
        public int OldFileId { get; set; }

        /// <summary>
        /// 新文件Id
        /// </summary>
        public int NewFileId { get; set; }
    }
}
