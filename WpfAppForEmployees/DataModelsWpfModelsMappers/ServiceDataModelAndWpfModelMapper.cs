using WpfAppForEmployees.WpfModels;
using DataModels;

namespace WpfAppForEmployees.DataModelsWpfModelsMappers
{
    public static class ServiceDataModelAndWpfModelMapper
    {
        public static ServiceDataModel ServiceModelToData(this ServiceWpfModel model)
        {
            return new ServiceDataModel
            {
                Id = model.Id,
                ServiceName = model.ServiceName,
                ServiceDescription = model.ServiceDescription,
                IsPublished = model.IsPublished
            };
        }

        public static ServiceWpfModel ServiceDataToModel(this ServiceDataModel data)
        {
            return new ServiceWpfModel
            {
                Id = data.Id,
                ServiceName = data.ServiceName,
                ServiceDescription = data.ServiceDescription,
                IsPublished = data.IsPublished
            };
        }
    }
}
