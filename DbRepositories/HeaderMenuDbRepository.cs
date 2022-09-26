using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Base;
using RepositoryInterfaces;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class HeaderMenuDbRepository : BaseDbRepository<HeaderMenuEntity, HeaderMenuDataModel>, IRepository<HeaderMenuDataModel>
    {
        public HeaderMenuDbRepository(DbContextProfiСonnector context)
            : base(context,
                  MenuEntityAndDataModelMapper.HeaderMenuEntityToData,
                  MenuEntityAndDataModelMapper.HeaderMenuDataToEntity)
        { }

        public async Task<HeaderMenuDataModel[]> GetAllDataModelsAsync()
        {
            var headerMenuSets = await Context.HeaderMenus
                .Select(m => MapEntityToData(m))
                .ToArrayAsync();

            return headerMenuSets;
        }
    }
}
