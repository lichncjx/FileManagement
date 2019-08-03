using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.ModelBaseInfos.Models.Dto;

namespace DHJ.FileManagement.ModelBaseInfos.Models
{
    public interface IModelInfoAppService : IApplicationService
    {
        Task CreateOrUpdateModelInfo(CreateOrUpdateModelInfoInput input);

        Task<GetModelInfoForEditOutput> GetModelInfoForEdit(NullableIdDto input);

        Task DeleteModelInfo(EntityDto input);

        Task<ListResultDto<ModelInfoListDto>> GetModelInfos();
    }
}