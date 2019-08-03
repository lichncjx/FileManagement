using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.ModelBaseInfos.Sections.Dto;

namespace DHJ.FileManagement.ModelBaseInfos.Sections
{
    public interface ISectionInfoAppService : IApplicationService
    {
        Task CreateOrUpdateSectionInfo(CreateOrUpdateSectionInfoInput input);

        Task<GetSectionInfoForEditOutput> GetSectionInfoForEdit(NullableIdDto input);

        Task DeleletSectionInfo(EntityDto input);

        Task<ListResultDto<SectionInfoListDto>> GetSectionInfosInModelInfo(EntityDto model);
    }
}