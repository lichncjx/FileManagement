using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.Files;

namespace DHJ.FileManagement.ModelBaseInfos.Sections.Dto
{
    public class GetSectionInfoForEditOutput
    {
        public GetSectionInfoForEditOutput()
        {
            Stages = GetStagesToComboBoxItemList();
        }

        public List<ComboboxItemDto> Stages { get; private set; }

        public SectionInfoEditDto SectionInfo { get; set; }

        /// <summary>
        /// 将阶段的枚举类型转换为ComboBoxItemDto列表
        /// </summary>
        /// <returns></returns>
        private List<ComboboxItemDto> GetStagesToComboBoxItemList()
        {
            var list = new List<ComboboxItemDto>();

            foreach (int value in Enum.GetValues(typeof(ProductStage)))
            {
                var item = new ComboboxItemDto(value.ToString(), Enum.GetName(typeof(ProductStage), value));
                list.Add(item);
            }

            return list;
        }
    }
}