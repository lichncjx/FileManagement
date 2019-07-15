using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Editions.Dto;

namespace DHJ.FileManagement.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}