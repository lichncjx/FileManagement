using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using DHJ.FileManagement.Authorization.Users;
using DHJ.FileManagement.Authorization.Users.Dto;
using DHJ.FileManagement.FileStore.StoreContainers;
using DHJ.FileManagement.FileStore.StoreContainers.Dto;
using Microsoft.EntityFrameworkCore;

namespace DHJ.FileManagement.FileStore
{
    public class StoreContainerAppService : FileManagementAppServiceBase, IStoreContainerAppService
    {
        private readonly IRepository<StoreContainer> _storeContainerRepository;
        private readonly IUserAppService _userAppService;

        public StoreContainerAppService(IRepository<StoreContainer> storeContainerRepository)
        {
            _storeContainerRepository = storeContainerRepository;
        }

        public async Task CreateOrUpdateStoreContainer(CreateOrUpdateStoreContainerInput input)
        {
            if (input.StoreContainer.Id.HasValue)
            {
                await UpdateStoreContainer(input);
            }
            else
            {
                await CreateStoreContainer(input);
            }
        }

        public async Task<GetStoreContainerForEditOutput> GetStoreContainerForEdit(NullableIdDto input)
        {
            var storeContainerEditDto = new StoreContainerEditDto();

            if (input.Id.HasValue)
            {
                var storeContainer = await _storeContainerRepository.FirstOrDefaultAsync(p => p.Id == input.Id);
                storeContainerEditDto.Name = storeContainer.Name;
                storeContainerEditDto.Describe = storeContainer.Describe;
                storeContainerEditDto.AdministratorIds = storeContainer.AdministratorIds;
            }

            return new GetStoreContainerForEditOutput()
            {
                StoreContainer = storeContainerEditDto,
                Users = ObjectMapper.Map<ListResultDto<UserListDto>>(UserManager.Users)
            };
        }

        public async Task DeleteStoreContainer(EntityDto input)
        {
            await _storeContainerRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<StoreContainerListDto>> GetStoreContainers()
        {
            var storeContainers = await _storeContainerRepository.GetAll().Where(p => p.FatherContainer == null).ToListAsync();

            var result = new List<StoreContainerListDto>();
            foreach (var container in storeContainers)
            {
                var containerListDto = new StoreContainerListDto();
                containerListDto.Name = container.Name;
                containerListDto.Describe = container.Describe;
                containerListDto.DisplayName = container.Name;
                containerListDto.Administrators = new List<string>();

                foreach (var userId in container.AdministratorIds)
                {
                   containerListDto.Administrators.Add(UserManager.GetUser(new UserIdentifier(null, userId)).Name);
                }
                result.Add(containerListDto);
            }

            return ObjectMapper.Map<ListResultDto<StoreContainerListDto>>(result);
        }

        public async Task<ListResultDto<StoreContainerListDto>> GetStoreContainers(EntityDto fatherContainer)
        {
            var storeContainer = await _storeContainerRepository.GetAllIncluding(p => p.StoreContainers)
                .FirstOrDefaultAsync(p => p.Id == fatherContainer.Id);

            var result = new List<StoreContainerListDto>();
            foreach (var container in storeContainer.StoreContainers)
            {
                var containerListDto = new StoreContainerListDto();
                containerListDto.Name = container.Name;
                containerListDto.Describe = container.Describe;
                containerListDto.DisplayName = container.Name;
                containerListDto.Administrators = new List<string>();

                foreach (var userId in container.AdministratorIds)
                {
                    containerListDto.Administrators.Add(UserManager.GetUser(new UserIdentifier(null, userId)).Name);
                }
                result.Add(containerListDto);
            }

            return ObjectMapper.Map<ListResultDto<StoreContainerListDto>>(result);
        }

        public async Task<StoreContainerListDto> GetStoreContainer(EntityDto input)
        {
            var storeContainer = await _storeContainerRepository.FirstOrDefaultAsync(p => p.Id == input.Id);

            var containerListDto = new StoreContainerListDto();
            containerListDto.Name = storeContainer.Name;
            containerListDto.Describe = storeContainer.Describe;
            containerListDto.DisplayName = storeContainer.Name;
            containerListDto.Administrators = new List<string>();
            foreach (var userId in storeContainer.AdministratorIds)
            {
                containerListDto.Administrators.Add(UserManager.GetUser(new UserIdentifier(null, userId)).Name);
            }

            return containerListDto;
        }

        public async Task<StoreContainerListDto> GetStoreContainer(string serailNumber)
        {
            var storeContainer = await _storeContainerRepository.FirstOrDefaultAsync(p => p.SerialNumber == serailNumber);

            var containerListDto = new StoreContainerListDto();
            containerListDto.Name = storeContainer.Name;
            containerListDto.Describe = storeContainer.Describe;
            containerListDto.DisplayName = storeContainer.Name;
            containerListDto.Administrators = new List<string>();
            foreach (var userId in storeContainer.AdministratorIds)
            {
                containerListDto.Administrators.Add(UserManager.GetUser(new UserIdentifier(null, userId)).Name);
            }

            return containerListDto;
        }

        private async Task CreateStoreContainer(CreateOrUpdateStoreContainerInput input)
        {
            var storeContainer = new StoreContainer(input.StoreContainer.Name)
            {
                AdministratorIds = input.StoreContainer.AdministratorIds,
                Describe = input.StoreContainer.Describe
            };

            if (input.FatherContainerId.HasValue)
            {
                var fatherStore =
                    await _storeContainerRepository.GetAllIncluding(p => p.StoreContainers).FirstOrDefaultAsync(p => p.Id == input.FatherContainerId);
                if (fatherStore != null)
                {
                    if (fatherStore.FileStoreInfos != null)
                    {
                        fatherStore.StoreContainers.Add(storeContainer);
                    }
                    else
                    {
                        fatherStore.StoreContainers = new List<StoreContainer> { storeContainer };
                    }
                }
                else
                {
                    throw new UserFriendlyException($"创建失败！未找到Id为{input.FatherContainerId.ToString()}的父容器");
                }
            }
            else
            {
                await _storeContainerRepository.InsertAsync(storeContainer);
            }
        }

        private async Task UpdateStoreContainer(CreateOrUpdateStoreContainerInput input)
        {
            var storeContainer =
                await _storeContainerRepository.FirstOrDefaultAsync(p => p.Id == input.StoreContainer.Id);
            if (storeContainer != null)
            {
                storeContainer.Name = input.StoreContainer.Name;
                storeContainer.AdministratorIds = input.StoreContainer.AdministratorIds;
                storeContainer.Describe = storeContainer.Describe;
            }
            else
            {
                throw new UserFriendlyException($"更新失败！未能找到Id为{input.StoreContainer.Id}的库存容器对象");
            }
        }
    }
}
