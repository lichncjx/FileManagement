using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Applications
{
    public class FileBorrowing : FullAuditedEntity
    {
        public int FileId { get; set; }

        public DateTime NeedTime { get; set; }

        public string FileType { get; set; }

        public string ProcessInstId { get; set; }

        public string OpenPassword { get; set; }
    }
}
