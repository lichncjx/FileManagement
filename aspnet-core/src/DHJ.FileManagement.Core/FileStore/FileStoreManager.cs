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
        private readonly IFileManagerBase<FileBase> _fileManager;
        private readonly IRepository<StoreBase> _storeBaseRepository;
        private readonly IRepository<FileStoreInfo> _fileStoreInfoRepository;

        public FileStoreManager(IFileManagerBase<FileBase> fileManager, IRepository<StoreBase> storeBaseRepository, IRepository<FileStoreInfo> fileStoreInfoRepository)
        {
            _fileManager = fileManager;
            _storeBaseRepository = storeBaseRepository;
            _fileStoreInfoRepository = fileStoreInfoRepository;
        }

        public async Task<FileBase> StockIn(string documentSerialNumber, string storeSerialNumber)
        {
            string errMessage = string.Empty; 
            var file = await _fileManager.GetFile(documentSerialNumber);

            if (file != null)
            {
                var box = await _storeBaseRepository.GetAllIncluding(p=>p.FileStoreInfos).FirstOrDefaultAsync(p => p.SerialNumber == storeSerialNumber);
                if (box != null)
                {
                    var fileStoreInfo = await _fileStoreInfoRepository.FirstOrDefaultAsync(p => p.FileId == file.Id);

                    if (fileStoreInfo != null)
                    {
                        fileStoreInfo.StoreState = StoreState.在库;
                        fileStoreInfo.StoreId.Id = box.Id;
                    }
                    else
                    {
                        fileStoreInfo = new FileStoreInfo
                        {
                            FileId = file.Id,
                            StoreState = StoreState.在库
                        };
                        box.FileStoreInfos.Add(fileStoreInfo);
                    }
                    
                    return file;
                }
                else
                {
                    errMessage = $"未找到编号[{boxNumber}]的文件盒";
                    throw new UserFriendlyException(errMessage);
                }
            }
            else
            {
                errMessage = $"未找到编号[{fileNumber}]的文件记录";
                throw new UserFriendlyException(errMessage);
            }
        }

        public async Task<FileBase> StockOut(string fileNumber)
        {
            string errMessage = string.Empty;
            var file = await _fileManager.GetFile(fileNumber);
            if (file != null)
            {
                var fileStoreInfo = await _fileStoreInfoRepository.FirstOrDefaultAsync(p => p.FileId == file.Id);

                if (fileStoreInfo != null)
                {
                    switch (fileStoreInfo.StoreState)
                    {
                        case StoreState.在库:
                            fileStoreInfo.StoreState = StoreState.已出库;
                            return file;
                        case StoreState.已出库:
                            errMessage = $"文件编号[{fileNumber}]的文件不在库中";
                            throw new UserFriendlyException(errMessage);
                        case StoreState.已报废:
                            errMessage = $"文件编号[{fileNumber}]的文件已报废";
                            throw new UserFriendlyException(errMessage);
                        default:
                            errMessage = $"文件编号[{fileNumber}]的文件库存状态异常";
                            throw new UserFriendlyException(errMessage);
                    }
                }
                else
                {
                    errMessage = $"文件编号[{fileNumber}]的文件还未入库";
                    throw new UserFriendlyException(errMessage);
                }
            }
            else
            {
                errMessage = $"未找到文件编号[{fileNumber}]的文件记录";
                throw new UserFriendlyException(errMessage);
            }
        }

        public async Task<FileBase> Scrap(string fileNumber)
        {
            var file = await _fileManager.GetFile(fileNumber);
            string errMessage = string.Empty;
            if (file != null)
            {
                var fileStoreInfo = await _fileStoreInfoRepository.FirstOrDefaultAsync(p => p.FileId == file.Id);
                if (fileStoreInfo != null)
                {
                    switch (fileStoreInfo.StoreState)
                    {
                        case StoreState.在库:
                            fileStoreInfo.StoreState = StoreState.已报废;
                            return file;
                        case StoreState.已出库:
                            errMessage = $"文件编号[{fileNumber}]的文件处于出库状态";
                            throw new UserFriendlyException(errMessage);
                        case StoreState.已报废:
                            errMessage = $"文件编号[{fileNumber}]的文件已经报废了";
                            throw new UserFriendlyException(errMessage);
                        default:
                            errMessage = $"文件编号[{fileNumber}]的文件库存状态异常";
                            throw new UserFriendlyException(errMessage);
                    }
                }
                else
                {
                    errMessage = $"文件编号[{fileNumber}]的文件还未入库";
                    throw new UserFriendlyException(errMessage);
                }
            }
            else
            {
                errMessage = $"未找到文件编号[{fileNumber}]的文件记录";
                throw new UserFriendlyException(errMessage);
            }
        }

        public async Task<FileBox> FindFile(int fileId)
        {
            var box = await _fileBoxRepository.GetAllIncluding(p=>p.FileStoreInfos).FirstOrDefaultAsync(p =>
                p.FileStoreInfos.Find(f => f.FileId == fileId).FileId == fileId);
            return box;
        }
    }
}