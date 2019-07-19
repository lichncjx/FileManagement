using System.Threading.Tasks;
using Abp.Domain.Services;
using DHJ.FileManagement.Files.FileEntities;

namespace DHJ.FileManagement.FileStore.Manager
{
    public interface IFileStoreManager : IDomainService
    {
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="fileNumber">文件编码</param>
        /// <param name="boxNumber">文件盒编号</param>
        /// <returns></returns>
        Task<FileBase> StockIn(string fileNumber, string boxNumber);

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="fileNumber">文件编码</param>
        /// <returns></returns>
        Task<FileBase> StockOut(string fileNumber);

        /// <summary>
        /// 报废
        /// </summary>
        /// <param name="fileNumber">文件编码</param>
        /// <returns></returns>
        Task<FileBase> Scrap(string fileNumber);

        Task<FileBox> FindFile(int fileId);
    }
}