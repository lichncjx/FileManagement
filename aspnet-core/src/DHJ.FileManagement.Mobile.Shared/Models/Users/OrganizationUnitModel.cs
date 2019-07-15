using Abp.AutoMapper;
using DHJ.FileManagement.Organizations.Dto;

namespace DHJ.FileManagement.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}