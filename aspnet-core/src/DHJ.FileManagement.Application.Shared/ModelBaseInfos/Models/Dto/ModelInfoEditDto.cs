using Abp.Application.Services.Dto;

namespace DHJ.FileManagement.ModelBaseInfos.Models.Dto
{
    public class ModelInfoEditDto : NullableIdDto
    {
        public string Name { get; set; }
    }
}