using WpfAppForEmployees.WpfModels;
using DataModels;

namespace WpfAppForEmployees.DataModelsWpfModelsMappers
{
    public static class ServiceDataModelAndWpfModelMapper
    {
        public static ServiceWpfModel ServiceDataModelToWpfModel(this ServiceDataModel data)
        {
            return new ServiceWpfModel
            {
                Id = data.Id,
                ServiceName = data.ServiceName,
                ServiceDescription = data.ServiceDescription,
                IsPublishedAsBool = data.IsPublished
            };
        }

        public static ServiceDataModel ServiceWpfModelToDataModel(this ServiceWpfModel model)
        {
            return new ServiceDataModel
            {
                Id = model.Id,
                ServiceName = model.ServiceName,
                ServiceDescription = model.ServiceDescription,
                IsPublished = model.IsPublishedAsBool
            };
        }
    }
}
