using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using DHJ.FileManagement.ModelBaseInfos.Models.Dto;
using DHJ.FileManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DHJ.FileManagement.ModelBaseInfos.Models
{
    public class ModelInfoAppService : FileManagementAppServiceBase, IModelInfoAppService
    {
        private readonly IRepository<ModelInfo> _modelInfoRepository;

        public ModelInfoAppService(IRepository<ModelInfo> modelInfoRepository)
        {
            _modelInfoRepository = modelInfoRepository;
        }

        public async Task CreateOrUpdateModelInfo(CreateOrUpdateModelInfoInput input)
        {
            if (input.ModelInfo.Id.HasValue)
            {
                await UpdateModelInfo(input);
            }
            else
            {
                await CreateModelInfo(input);
            }
        }

        public async Task<GetModelInfoForEditOutput> GetModelInfoForEdit(NullableIdDto input)
        {
            var modelInfoEditDto = new ModelInfoEditDto();
            if (input.Id.HasValue)
            {
                var modelInfo = await _modelInfoRepository.FirstOrDefaultAsync(p => p.Id == input.Id.Value);
                if (modelInfo != null)
                {
                    modelInfoEditDto.Name = modelInfo.Name;
                }
                else
                {
                    throw new UserFriendlyException($"未获取到Id是{input.Id.ToString()}的型号基础信息");
                }
            }

            return new GetModelInfoForEditOutput
            {
                ModelInfo = modelInfoEditDto
            };
        }

        public async Task DeleteModelInfo(EntityDto input)
        {
            await _modelInfoRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<ModelInfoListDto>> GetModelInfos()
        {
            var modelInfos = await _modelInfoRepository.GetAllIncluding(p => p.SectionInfo).ToListAsync();
            return new ListResultDto<ModelInfoListDto>(ObjectMapper.Map<List<ModelInfoListDto>>(modelInfos));
        }

        private async Task CreateModelInfo(CreateOrUpdateModelInfoInput input)
        {
            var modelInfo = new ModelInfo(input.ModelInfo.Name);
            await _modelInfoRepository.InsertAsync(modelInfo);
        }

        private async Task UpdateModelInfo(CreateOrUpdateModelInfoInput input)
        {
            var modelInfo = await _modelInfoRepository.FirstOrDefaultAsync(p => p.Id == input.ModelInfo.Id.Value);
            if (modelInfo != null)
            {
                modelInfo.Name = input.ModelInfo.Name;
            }
            else
            {
                throw new UserFriendlyException($"未获取到Id是{input.ModelInfo.Id.ToString()}的型号基础信息");
            }
        }
    }
}
