using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using DHJ.FileManagement.ModelBaseInfos.Sections.Dto;
using DHJ.FileManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DHJ.FileManagement.ModelBaseInfos.Sections
{
    public class SectionInfoAppService : FileManagementAppServiceBase, ISectionInfoAppService
    {
        private readonly IRepository<ModelInfo> _modelInfoRepository;

        public SectionInfoAppService(IRepository<ModelInfo> modelInfoRepository)
        {
            _modelInfoRepository = modelInfoRepository;
        }

        public async Task CreateOrUpdateSectionInfo(CreateOrUpdateSectionInfoInput input)
        {
            if (input.SectionInfo.Id.HasValue)
            {
                await UpdateSectionInfo(input);
            }
            else
            {
                await CreateSectionInfo(input);
            }
        }

        public async Task<GetSectionInfoForEditOutput> GetSectionInfoForEdit(NullableIdDto input)
        {
            var sectionInfoEditDto = new SectionInfoEditDto();

            if (input.Id.HasValue)
            {
                var section = (await _modelInfoRepository.GetAllIncluding(p => p.SectionInfo)
                        .FirstOrDefaultAsync(p => p.SectionInfo.FirstOrDefault(x => x.Id == input.Id).Id == input.Id))
                        .SectionInfo.FirstOrDefault(p => p.Id == input.Id);

                sectionInfoEditDto.Name = section.Name;
                sectionInfoEditDto.DrawingNumber = section.DrawingNumber;
                sectionInfoEditDto.ProductStage = section.ProductStage;
            }

            return new GetSectionInfoForEditOutput()
            {
                SectionInfo = sectionInfoEditDto
            };
        }

        public async Task DeleletSectionInfo(EntityDto input)
        {
            var modelInfo = await _modelInfoRepository.GetAllIncluding(p => p.SectionInfo)
                .FirstOrDefaultAsync(p => p.SectionInfo.FirstOrDefault(x => x.Id == input.Id).Id == input.Id);

            modelInfo.SectionInfo.Remove(modelInfo.SectionInfo.FirstOrDefault(x => x.Id == input.Id));
        }

        public async Task<ListResultDto<SectionInfoListDto>> GetSectionInfosInModelInfo(EntityDto model)
        {
            var modelInfo = await _modelInfoRepository.GetAllIncluding(p => p.SectionInfo)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (modelInfo != null)
            {
                return new ListResultDto<SectionInfoListDto>(ObjectMapper.Map<List<SectionInfoListDto>>(modelInfo.SectionInfo));
            }
            else
            {
                throw new UserFriendlyException($"未获取到Id为{model.Id.ToString()}的型号对象");
            }
        }

        private async Task CreateSectionInfo(CreateOrUpdateSectionInfoInput input)
        {
            var modelInfo = await _modelInfoRepository.GetAllIncluding(p => p.SectionInfo).FirstOrDefaultAsync(p => p.Id == input.ModelInfoId);
            var section = new SectionInfo(input.SectionInfo.Name, input.SectionInfo.ProductStage);
            section.DrawingNumber = input.SectionInfo.DrawingNumber;

            if (modelInfo != null)
            {
                if (modelInfo.SectionInfo != null)
                {
                    modelInfo.SectionInfo.Add(section);
                }
                else
                {
                    modelInfo.SectionInfo = new List<SectionInfo> { section };
                }
            }
            else
            {
                throw new UserFriendlyException($"未获取到Id为{input.ModelInfoId.ToString()}的型号对象");
            }
        }

        private async Task UpdateSectionInfo(CreateOrUpdateSectionInfoInput input)
        {
            var modelInfo = await _modelInfoRepository.GetAllIncluding(p => p.SectionInfo).FirstOrDefaultAsync(p => p.Id == input.ModelInfoId);

            if (modelInfo != null)
            {
                var section = modelInfo.SectionInfo.FirstOrDefault(p => p.Id == input.SectionInfo.Id);

                if (section != null)
                {
                    section.Name = input.SectionInfo.Name;
                    section.DrawingNumber = input.SectionInfo.DrawingNumber;
                    section.ProductStage = input.SectionInfo.ProductStage;
                }
                else
                {
                    throw new UserFriendlyException($"未获取到Id为{input.SectionInfo.Id.ToString()}的部段对象");
                }
            }
            else
            {
                throw new UserFriendlyException($"未获取到Id为{input.ModelInfoId.ToString()}的型号对象");
            }
        }
    }
}
