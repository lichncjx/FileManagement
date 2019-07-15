using Abp.AutoMapper;
using DHJ.FileManagement.MultiTenancy;
using DHJ.FileManagement.MultiTenancy.Dto;
using DHJ.FileManagement.Web.Areas.AppAreaName.Models.Common;

namespace DHJ.FileManagement.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}