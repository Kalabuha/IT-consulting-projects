using DataModels;
using WebModels;

namespace DataModelsWebModelsMappers
{
    public static class ServiceDataModelAndWebModelMapper
    {
        public static ServiceDataModel ServiceModelToData(this ServiceWebModel model)
        {
            return new ServiceDataModel
            {
                Id = model.Id,
                ServiceName = model.ServiceName,
                ServiceDescription = model.ServiceDescription,
                IsPublished = model.IsPublished
            };
        }

        public static ServiceWebModel ServiceDataToModel(this ServiceDataModel data)
        {
            return new ServiceWebModel
            {
                Id = data.Id,
                ServiceName = data.ServiceName,
                ServiceDescription = data.ServiceDescription,
                IsPublished = data.IsPublished
            };
        }
    }
}
