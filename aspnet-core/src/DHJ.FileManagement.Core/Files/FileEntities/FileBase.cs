using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace DHJ.FileManagement.Files.FileEntities
{
    public class FileBase : FullAuditedEntity
    {
        public FileBase(string fileName)
        {
            FileName = fileName;
            FileNumber = FileNumberFactory.Create();
        }

        public FileBase()
        {
        }

        /// <summary>
        /// 文件名
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// 档案编号
        /// </summary>
        [Required]
        public string FileNumber { get; private set; }

        /// <summary>
        /// 页数
        /// </summary>
        public virtual int Pages { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        public virtual int? LocationId { get; set; }
    }
}
