using WebModels;
using DataModels;

namespace DataModelsWebModelsMappers
{
    public static class SloganDataModelAndWebModelMapper
    {
        public static HeaderSloganDataModel SloganModelToData(this HeaderSloganWebModel model)
        {
            return new HeaderSloganDataModel
            {
                Id = model.Id,
                Slogan = model.Slogan,
                IsUsed = model.IsUsed
            };
        }

        public static HeaderSloganWebModel SloganDataToModel(this HeaderSloganDataModel data)
        {
            return new HeaderSloganWebModel
            {
                Id = data.Id,
                Slogan = data.Slogan,
                IsUsed = data.IsUsed
            };
        }
    }
}
