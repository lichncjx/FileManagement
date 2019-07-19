using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using DHJ.FileManagement.Files.FileFeatures;

namespace DHJ.FileManagement.Files.FileEntities
{
    public class FileManagerBase<T> : DomainService,IFileManagerBase<T> where T : FileBase
    {
        private readonly IRepository<T> _tRepository;
        public FileManagerBase(IRepository<T> tRepository)
        {
            _tRepository = tRepository;
        }
        public async Task<int> CreateFile(T file)
        {
            return await _tRepository.InsertAndGetIdAsync(file);
        }

        public async Task<T> UpdateFile(T file)
        {
            return await _tRepository.UpdateAsync(file);
        }

        public async Task DeleteFile(int id)
        {
            await _tRepository.DeleteAsync(id);
        }

        public async Task<T> GetFile(int id)
        {
            return await _tRepository.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<T> GetFile(string fileNumber)
        {
            return await _tRepository.FirstOrDefaultAsync(p => p.FileNumber == fileNumber);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> lambda)
        {
            return await _tRepository.GetAllListAsync(lambda);
        }


        /// <summary>
        /// 自定义特性查询
        /// </summary>
        /// <param name="fileObj"></param>
        /// <param name="lambd"></param>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public IEnumerable<T> GetObjsByCustomFeature(Expression<Func<T, bool>> lambda)
        {
            return _tRepository.GetAllList(lambda);
        }

        public IEnumerable<T> GetSameObjsByCurrent(T fileObj, params Type[] featureTypes)
        {
            IEnumerable<T> filterFile = _tRepository.GetAll();

            foreach (var type in featureTypes)
            {
                if (!(typeof(T).IsInstanceOfType(featureTypes)))
                {
                    string message = $"[{featureTypes.GetType().Name}]特性不属于[{fileObj.GetType().Name}]对象";
                    throw new Exception(message);
                }
                else
                {
                    string fullName = type.Namespace + "." + type.Name.Substring(3) + "Manager";//命名空间.类型名
                    object[] parameters = new object[1];
                    parameters[0] = _tRepository;
                    try
                    {
                        IFileFeatureManagerBase<T> ect = (IFileFeatureManagerBase<T>)Assembly.GetExecutingAssembly().CreateInstance(fullName, true, BindingFlags.Default, null, parameters, null, null);
                        filterFile = ect.GetObjByCurrentFeature(filterFile, fileObj);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }

            return filterFile.ToList();
        }

        public IEnumerable<T> GetSameObjsByCurrent(T fileObj)
        {
            var featureTypes = typeof(T).GetInterfaces();

            IEnumerable<T> filterFile = _tRepository.GetAll();

            foreach (var type in featureTypes)
            {
                if (featureTypes.GetType().Name.Contains("IHas") && featureTypes.GetType().Name.Contains("info"))
                {
                    if (!(typeof(T).IsInstanceOfType(featureTypes)))
                    {
                        //string message = "{" + featureTypes.GetType().Name + "}特性不属于{" + fileObj.GetType().Name + "}对象。";
                        string message = $"[{featureTypes.GetType().Name}]特性不属于[{fileObj.GetType().Name}]对象";
                        throw new Exception(message);
                    }
                    else
                    {
                        string fullName = type.Namespace + "." + type.Name.Substring(3) + "Manager";//命名空间.类型名
                        object[] parameters = new object[1];
                        parameters[0] = _tRepository;
                        try
                        {
                            IFileFeatureManagerBase<T> ect = (IFileFeatureManagerBase<T>)Assembly.GetExecutingAssembly().CreateInstance(fullName, true, BindingFlags.Default, null, parameters, null, null);
                            filterFile = ect.GetObjByCurrentFeature(filterFile, fileObj);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                    }
                }
            }

            return filterFile.ToList();
        }
    }
}