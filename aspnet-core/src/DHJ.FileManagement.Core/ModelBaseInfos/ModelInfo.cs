using Abp.Domain.Entities.Auditing;
using DHJ.FileManagement.ModelBaseInfos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHJ.FileManagement.Models
{
    public class ModelInfo : FullAuditedEntity
    {
        public ModelInfo(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 部段 
        /// </summary>
        public virtual ICollection<SectionInfo> SectionInfo { get; set; }
    }
}