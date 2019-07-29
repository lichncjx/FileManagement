using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.ModelBaseInfos.Models.Dto;

namespace DHJ.FileManagement.ModelBaseInfos.Models
{
    public interface IModelAppService : IApplicationService
    {
        Task CreateOrUpdateModel(CreateOrUpdateModelInfoInput input);

        Task<GetModelInfoForEditOutput> GetModelForEdit(NullableIdDto input);

        Task DeleteModel(EntityDto input);
    }
}