using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.FileStore.Manager
{
    public class FileStoreManager : DomainService, IFileStoreManager
    {
        private readonly IFileManagerBase<FileBase> _fileManager;
        private readonly IRepository<FileBox> _fileBoxRepository;

        public FileStoreManager(IFileManagerBase<FileBase> fileManager, IRepository<FileBox> fileBoxRepository)
        {
            _fileManager = fileManager;
            _fileBoxRepository = fileBoxRepository;
        }

        public Task<FileBase> StockIn(string fileNumber, int boxId)
        {
            var file = _fileManager.GetFile(fileNumber);

            if (file != null)
            {
                var box = _fileBoxRepository.FirstOrDefault(p => p.Id == boxId);
                if (box != null)
                {
                    box.FileId.Add(file.Id);
                }
            }
        }

        public Task<FileBase> StockOut(string fileNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<FileBase> Scrap(string fileNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}