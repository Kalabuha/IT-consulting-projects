using Entities.Base;
using DataModels.Base;

namespace MapperDelegates
{
    public delegate TEntityResult DataToEntityFunc<in TData, in TEntity, out TEntityResult>(TData data, TEntity? entity = null)
        where TEntityResult : BaseEntity
        where TEntity : BaseEntity
        where TData : BaseDataModel;
}