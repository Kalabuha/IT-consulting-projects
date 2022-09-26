using DataModels.Base;

namespace RepositoryInterfaces
{
    public interface IRepository<TData> : IBaseRepository<TData> where TData : BaseDataModel
    {
        Task<TData[]> GetAllDataModelsAsync();
    }
}
