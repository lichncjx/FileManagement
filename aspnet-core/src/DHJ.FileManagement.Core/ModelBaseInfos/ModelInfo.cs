using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities.Auditing;
using DHJ.FileManagement.ModelBaseInfos;

namespace DHJ.FileManagement.Models
{
    public class ModelInfo : FullAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部段
        /// </summary>
        public IEnumerable<SectionInfo> SectionInfo { get; set; }
    }
}