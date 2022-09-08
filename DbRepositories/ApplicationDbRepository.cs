using Microsoft.EntityFrameworkCore;
using DbContextProfi;
using DbRepositories.Base;
using RepositoryInterfaces;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class ApplicationDbRepository : BaseDbRepository<ApplicationEntity>, IApplicationRepository
    {
        public ApplicationDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<ApplicationDataModel?> GetApplicationAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.ApplicationEntityToData();
        }

        public async Task<ApplicationDataModel[]> GetAllApplicationAsync()
        {
            var applications = await Context.Applications
                .Select(a => a.ApplicationEntityToData())
                .ToArrayAsync();

            return applications;
        }

        public async Task<int> AddApplicationAsync(ApplicationDataModel data)
        {
            var entity = data.ApplicationDataToEntity();
            await AddEntityAsync(entity);
            return entity.Number;
        }

        public async Task<bool> UpdateApplicationAsync(ApplicationDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.ApplicationDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteApplicationAsync(int id)
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
