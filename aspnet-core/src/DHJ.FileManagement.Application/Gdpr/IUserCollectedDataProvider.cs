using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using DHJ.FileManagement.Dto;

namespace DHJ.FileManagement.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
