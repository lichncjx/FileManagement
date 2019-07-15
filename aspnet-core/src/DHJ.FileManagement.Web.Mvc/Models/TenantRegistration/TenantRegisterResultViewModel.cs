using Abp.AutoMapper;
using DHJ.FileManagement.MultiTenancy.Dto;

namespace DHJ.FileManagement.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}