using DataModels;
using WebModels;

namespace DataModelsWebModelsConverters
{
    public static class ServiceDataModelAndWebModelConverter
    {
        public static ServiceData ServiceModelToData(this ServiceModel model)
        {
            return new ServiceData
            {
                Id = model.Id,
                ServiceName = model.ServiceName,
                ServiceDescription = model.ServiceDescription,
                IsPublished = model.IsPublished
            };
        }

        public static ServiceModel ServiceDataToModel(this ServiceData data)
        {
            return new ServiceModel
            {
                Id = data.Id,
                ServiceName = data.ServiceName,
                ServiceDescription = data.ServiceDescription,
                IsPublished = data.IsPublished
            };
        }
    }
}
