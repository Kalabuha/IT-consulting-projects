using Microsoft.EntityFrameworkCore;
using DbContextProfi;
using DbRepositories.Base;
using RepositoryInterfaces;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class ApplicationDbRepository : BaseDbRepository<ApplicationEntity, ApplicationDataModel>, IRepository<ApplicationDataModel>
    {
        public ApplicationDbRepository(DbContextProfiСonnector context)
            : base(context,
                  ApplicationEntityAndDataModelMapper.ApplicationEntityToData,
                  ApplicationEntityAndDataModelMapper.ApplicationDataToEntity)
        { }

        public async Task<ApplicationDataModel[]> GetAllDataModelsAsync()
        {
            var applications = await Context.Applications
                .Select(a => MapEntityToData(a))
                .ToArrayAsync();

            return applications;
        }
    }
}
