using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.Models
{
    public class Model : FullAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}