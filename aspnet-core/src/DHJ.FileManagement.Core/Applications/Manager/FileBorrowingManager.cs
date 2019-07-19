using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Applications.Manager
{
    public class FileBorrowingManager : DomainService, IFileBorrowingManager
    {
        private readonly IRepository<FileBorrowing> _fileBorrowingRepository;
        private readonly IRepository<ProcessHistory> _processHistoryRepository;

        public FileBorrowingManager(IRepository<FileBorrowing> fileBorrowingRepository, IRepository<ProcessHistory> processHistoryRepository)
        {
            _fileBorrowingRepository = fileBorrowingRepository;
            _processHistoryRepository = processHistoryRepository;
        }


        public async Task<int> Create(FileBorrowing borrowing)
        {
            return await _fileBorrowingRepository.InsertAndGetIdAsync(borrowing);
        }

        
    }
}
