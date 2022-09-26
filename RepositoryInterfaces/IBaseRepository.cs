using DataModels.Base;

namespace RepositoryInterfaces
{
    public interface IBaseRepository<TData> where TData : BaseDataModel
    {
        Task<TData?> GetDataModelAsync(int id);
        Task<TData> AddDataModelAsync(TData data);
        Task<bool> UpdateDataModelAsync(TData data);
        Task<bool> DeleteDataModelAsync(int id);
    }
}
