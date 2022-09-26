using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Base;
using RepositoryInterfaces;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class HeaderSloganDbRepository : BaseDbRepository<HeaderSloganEntity, HeaderSloganDataModel>, IRepository<HeaderSloganDataModel>
    {
        public HeaderSloganDbRepository(DbContextProfiСonnector context)
            : base(context,
                  SloganEntityAndDataModelMapper.HeaderSloganEntityToData,
                  SloganEntityAndDataModelMapper.HeaderSloganDataToEntity)
        { }

        public async Task<HeaderSloganDataModel[]> GetAllDataModelsAsync()
        {
            var slogans = await Context.HeaderSlogans
                .Select(h => MapEntityToData.Invoke(h))
                .ToArrayAsync();

            return slogans;
        }
    }
}
