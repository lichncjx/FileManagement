using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DHJ.FileManagement.Files.FileEntities
{
    public interface IFileManagerBase<T> where T : FileBase
    {
        Task<int> CreateFile(T file);
        Task<T> UpdateFile(T file);
        Task DeleteFile(int id);
        Task<T> GetFile(int id);
        Task<T> GetFile(string fileNumber);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> lambda);

        IEnumerable<T> GetObjsByCustomFeature(Expression<Func<T, bool>> lambda);
        IEnumerable<T> GetSameObjsByCurrent(T fileObj, params Type[] featureTypes);
        IEnumerable<T> GetSameObjsByCurrent(T fileObj);
    }
}