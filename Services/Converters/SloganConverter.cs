using Resources.Entities;
using Resources.Datas;
using Resources.Models;

namespace Services.Converters
{
    public static class SloganConverter
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

        public static SloganData SloganModelToData(this SloganModel model)
        {
            return new SloganData
            {
                Id = model.Id,
                Slogan = model.Slogan,
                IsUsed = model.IsUsed
            };
        }

        public static SloganModel SloganDataToModel(this SloganData data)
        {
            return new SloganModel
            {
                Id = data.Id,
                Slogan = data.Slogan,
                IsUsed = data.IsUsed
            };
        }
    }
}
