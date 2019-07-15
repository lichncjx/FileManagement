using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.FileStore
{
    //档案库房
    public class StoreRoom : StoreBase
    {
        private IQueryable<FileCabinet> Cabinets { get; set; }
    }
}
