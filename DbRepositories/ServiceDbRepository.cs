using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class ServiceDbRepository : BaseDbRepository<ServiceEntity, ServiceDataModel>, IRepository<ServiceDataModel>
    {
        public ServiceDbRepository(DbContextProfiСonnector context)
            : base(context,
                  ServiceEntityAndDataModelMapper.ServiceEntityToData,
                  ServiceEntityAndDataModelMapper.ServiceDataToEntity)
        { }

        public async Task<ServiceDataModel[]> GetAllDataModelsAsync()
        {
            var services = await Context.Services
                .Select(s => MapEntityToData(s))
                .ToArrayAsync();

            return services;
        }
    }
}
