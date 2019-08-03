using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using DHJ.FileManagement.Files.FileEntities;
using Microsoft.EntityFrameworkCore;

namespace DHJ.FileManagement.FileStore
{
    public class FileStoreManager : DomainService
    {
        private readonly IRepository<FileStoreInfo> _fileStoreInfoRepository;

        public FileStoreManager(IRepository<FileStoreInfo> fileStoreInfoRepository)
        {
            _fileStoreInfoRepository = fileStoreInfoRepository;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <param name="storeContainer">存放容器对象</param>
        /// <returns></returns>
        public async Task StockIn(FileBase file, StoreContainer storeContainer)
        {
            string errMessage = string.Empty;
            var fileStoreInfo = await _fileStoreInfoRepository.FirstOrDefaultAsync(p => p.FileId == file.Id);

            if (fileStoreInfo != null)
            {
                switch (fileStoreInfo.StoreState)
                {
                    case StoreState.已出库:
                        fileStoreInfo.StoreState = StoreState.在库;
                        fileStoreInfo.FileContainerId = storeContainer.Id;
                        break;
                    case StoreState.在库:
                        errMessage = $"档案编号[{file.DocumentSerialNumber}]状态为：[已入库]，请检查";
                        break;
                    case StoreState.已报废:
                        errMessage = $"档案编号{file.DocumentSerialNumber}状态为：已报废，不可入库";
                        break;
                }
            }
            else
            {
                fileStoreInfo = new FileStoreInfo
                {
                    FileId = file.Id,
                    FileType = file.GetType().FullName,
                    FileContainerId = storeContainer.Id,
                    StoreState = StoreState.在库
                };
                await _fileStoreInfoRepository.InsertAsync(fileStoreInfo);
            }

            if (!string.IsNullOrEmpty(errMessage))
            {
                throw new UserFriendlyException(errMessage);
            }
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <returns>存放容器Id</returns>
        public async Task<int> StockOut(FileBase file)
        {
            string errMessage;
            var fileStoreInfo = await _fileStoreInfoRepository.FirstOrDefaultAsync(p => p.FileId == file.Id);

            if (fileStoreInfo != null)
            {
                switch (fileStoreInfo.StoreState)
                {
                    case StoreState.在库:
                        fileStoreInfo.StoreState = StoreState.已出库;
                        return fileStoreInfo.FileContainerId;
                    case StoreState.已出库:
                        errMessage = $"档案编号[{file.DocumentSerialNumber}]的文件不在库中";
                        throw new UserFriendlyException(errMessage);
                    case StoreState.已报废:
                        errMessage = $"档案编号[{file.DocumentSerialNumber}]的文件已报废";
                        throw new UserFriendlyException(errMessage);
                    default:
                        errMessage = $"档案编号[{file.DocumentSerialNumber}]的状态异常";
                        throw new UserFriendlyException(errMessage);
                }
            }
            else
            {
                errMessage = $"档案编号[{file.DocumentSerialNumber}]的文件还未入库";
                throw new UserFriendlyException(errMessage);
            }
        }

        /// <summary>
        /// 报废
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <param name="storeContainer">存放容器对象（不换位置可不传参）</param>
        /// <returns></returns>
        public async Task Scrap(FileBase file, StoreContainer storeContainer = null)
        {
            string errMessage = string.Empty;

            var fileStoreInfo = await _fileStoreInfoRepository.FirstOrDefaultAsync(p => p.FileId == file.Id);
            if (fileStoreInfo != null)
            {
                switch (fileStoreInfo.StoreState)
                {
                    case StoreState.在库:
                        fileStoreInfo.StoreState = StoreState.已报废;
                        if (storeContainer != null)
                            fileStoreInfo.FileContainerId = storeContainer.Id;
                        break;
                    case StoreState.已出库:
                        errMessage = $"档案编号[{file.DocumentSerialNumber}]的文件处于出库状态";
                        break;
                    case StoreState.已报废:
                        errMessage = $"档案编号[{file.DocumentSerialNumber}]的文件已经报废了";
                        break;
                }
            }
            else
            {
                errMessage = $"档案编号[{file.DocumentSerialNumber}]的文件还未入库";
                throw new UserFriendlyException(errMessage);
            }

            if (string.IsNullOrEmpty(errMessage))
            {
                throw new UserFriendlyException(errMessage);
            }
        }

        /// <summary>
        /// 获取文件存放信息
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<FileStoreInfo> GetFileStoreInfo(FileBase file)
        {
            return await _fileStoreInfoRepository.FirstOrDefaultAsync(p => p.FileId == file.Id);
        }
    }
}