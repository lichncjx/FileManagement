using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Editions.Dto;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}