using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using DHJ.FileManagement.Files;

namespace DHJ.FileManagement.ModelBaseInfos
{
    public class SectionInfo : FullAuditedEntity
    {
        public SectionInfo(string name, ProductStage productStage)
        {
            Name = name;
            ProductStage = productStage;
        }

        /// <summary>
        /// 部段名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 部段图号
        /// </summary>
        public string DrawingNumber { get; set; }

        /// <summary>
        /// 所属阶段
        /// </summary>
        [Required]
        public ProductStage ProductStage { get; set; }
    }
}