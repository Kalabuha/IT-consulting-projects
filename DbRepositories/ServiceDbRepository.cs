using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class ServiceDbRepository : BaseDbRepository<ServiceEntity>, IServiceRepository
    {
        public ServiceDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<ServiceDataModel?> GetServiceAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.ServiceEntityToData();
        }

        public async Task<ServiceDataModel[]> GetAllServiceAsync()
        {
            var services = await Context.Services
                .Select(s => s.ServiceEntityToData())
                .ToArrayAsync();

            return services;
        }

        public async Task<int> AddServiceAsync(ServiceDataModel data)
        {
            var entity = data.ServiceDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateServiceAsync(ServiceDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.ServiceDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity == null)
            {
                return false;
            }

            await RemoveEntityAsync(entity);
            return true;
        }
    }
}
