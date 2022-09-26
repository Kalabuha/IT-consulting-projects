using DataModels;
using ApiModels;

namespace DataModelsApiModelsMappers
{
    public static class ServiceDataModelAndApiModelMapper
    {
        public static ServiceDataModel ServiceApiToData(this ServiceApiModel api)
        {
            return new ServiceDataModel
            {
                Id = api.Id,
                ServiceName = api.ServiceName ?? string.Empty,
                ServiceDescription = api.ServiceDescription ?? string.Empty,
                IsPublished = api.IsPublished ?? false
            };
        }

        public static ServiceApiModel ServiceDataToApi(this ServiceDataModel data)
        {
            return new ServiceApiModel
            {
                Id = data.Id,
                ServiceName = data.ServiceName,
                ServiceDescription = data.ServiceDescription,
                IsPublished = data.IsPublished
            };
        }
    }
}
