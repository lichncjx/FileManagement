using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace DHJ.FileManagement.Files.FileEntities.Technologies.Manager
{
    public class TechnologyManager : FileManagerBase<Technology>, ITechnologyManager
    {
        public TechnologyManager(IRepository<Technology> tRepository) : base(tRepository)
        {
        }
    }
}
