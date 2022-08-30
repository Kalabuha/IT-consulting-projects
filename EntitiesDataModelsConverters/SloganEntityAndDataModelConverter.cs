using DataModels;
using Entities;

namespace EntitiesDataModelsConverters
{
    public static class SloganEntityAndDataModelConverter
    {
        public static SloganData SloganEntityToData(this SloganEntity entity)
        {
            return new SloganData
            {
                Id = entity.Id,
                Slogan = entity.Slogan,
                IsUsed = entity.IsUsed,
            };
        }

        public static SloganEntity SloganDataToEntity(this SloganData data, SloganEntity? entity = null)
        {
            entity ??= new SloganEntity();

            entity.Id = data.Id;
            entity.Slogan = data.Slogan;
            entity.IsUsed = data.IsUsed;

            return entity;
        }
    }
}
