using DHJ.FileManagement.Dto;

namespace DHJ.FileManagement.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}