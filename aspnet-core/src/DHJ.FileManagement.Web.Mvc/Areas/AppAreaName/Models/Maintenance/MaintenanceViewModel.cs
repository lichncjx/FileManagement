using System.Collections.Generic;
using DHJ.FileManagement.Caching.Dto;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}