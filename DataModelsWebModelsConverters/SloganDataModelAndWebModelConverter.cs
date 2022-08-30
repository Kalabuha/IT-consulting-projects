using WebModels;
using DataModels;

namespace DataModelsWebModelsConverters
{
    public static class SloganDataModelAndWebModelConverter
    {
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
