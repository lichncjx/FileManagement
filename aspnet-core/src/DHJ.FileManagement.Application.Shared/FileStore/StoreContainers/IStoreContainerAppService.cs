using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.FileStore.StoreContainers.Dto;

namespace DHJ.FileManagement.FileStore.StoreContainers
{
    public interface IStoreContainerAppService : IApplicationService
    {
        Task CreateOrUpdateStoreContainer(CreateOrUpdateStoreContainerInput input);

        Task<GetStoreContainerForEditOutput> GetStoreContainerForEdit(NullableIdDto input);

        Task DeleteStoreContainer(EntityDto input);

        Task<ListResultDto<StoreContainerListDto>> GetStoreContainers();

        Task<ListResultDto<StoreContainerListDto>> GetStoreContainers(EntityDto fatherContainer);

        Task<StoreContainerListDto> GetStoreContainer(EntityDto input);

        Task<StoreContainerListDto> GetStoreContainer(string serailNumber);
    }
}