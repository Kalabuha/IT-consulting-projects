using ResourcesApi.Base;
using Resources.Entities.Base;

namespace RepositoriesApi.Interfaces
{
    public interface IRepositoryApi<TEntity, TResource>
        where TEntity : BaseEntity
        where TResource : BaseResource
    {
        public Task<TEntity?> GetResource(int id);
        public Task<bool> AddResourceAsync(TResource resource);
        public Task<bool> UpdateResourceAsync(TResource resource);
        public Task<bool> DeleteResourceAsync(int id);
    }
}
