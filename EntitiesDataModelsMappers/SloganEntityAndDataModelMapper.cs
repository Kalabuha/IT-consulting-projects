using DataModels;
using Entities;

namespace EntitiesDataModelsMappers
{
    public static class SloganEntityAndDataModelMapper
    {
        public static HeaderSloganDataModel HeaderSloganEntityToData(HeaderSloganEntity entity)
        {
            return new HeaderSloganDataModel
            {
                Id = entity.Id,
                Slogan = entity.Slogan,
                IsUsed = entity.IsUsed,
            };
        }

        public static HeaderSloganEntity HeaderSloganDataToEntity(HeaderSloganDataModel data, HeaderSloganEntity? entity = null)
        {
            entity ??= new HeaderSloganEntity();

            entity.Id = data.Id;
            entity.Slogan = data.Slogan;
            entity.IsUsed = data.IsUsed;

            return entity;
        }
    }
}
