using System.Threading.Tasks;
using Abp.Domain.Services;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.Applications.Manager
{
    public interface IFileBorrowingManager : IDomainService
    {
        Task<int> Create(FileBorrowing borrowing);

    }
}