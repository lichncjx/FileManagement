using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using DHJ.FileManagement.SerialNumbers;

namespace DHJ.FileManagement.FileStore
{
    public class StoreContainer : FullAuditedEntity
    {
        public StoreContainer(string name)
        {
            Name = name;
            SerialNumber = SerialNumberFactory.Create();
        }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string SerialNumber { get; private set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        public StoreContainer FatherContainer { get; set; }

        public ICollection<StoreContainer> StoreContainers { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public ICollection<long> AdministratorIds { get; set; }
    }
}