using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using DHJ.FileManagement.SerialNumbers;

namespace DHJ.FileManagement.Files.FileEntities
{
    public abstract class FileBase : FullAuditedEntity
    {
        protected FileBase(string fileName)
        {
            FileName = fileName;
            DocumentSerialNumber = SerialNumberFactory.Create();
        }

        protected FileBase()
        {
        }

        /// <summary>
        /// 文件名
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// 文件自身的编号
        /// </summary>
        public string FileNumber { get; set; }

        /// <summary>
        /// 统一档案编号
        /// </summary>
        public string DocumentSerialNumber { get; private set; }
    }
}
