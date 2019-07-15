using System.Collections.Generic;
using Abp.Localization;
using DHJ.FileManagement.Install.Dto;

namespace DHJ.FileManagement.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
