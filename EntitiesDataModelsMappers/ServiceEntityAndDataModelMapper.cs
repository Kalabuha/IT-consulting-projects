using DataModels;
using Entities;

namespace EntitiesDataModelsMappers
{
    public static class ServiceEntityAndDataModelMapper
    {
        public static ServiceDataModel ServiceEntityToData(ServiceEntity entity)
        {
            return new ServiceDataModel
            {
                Id = entity.Id,
                ServiceName = entity.Title,
                ServiceDescription = entity.ServiceDescription,
                IsPublished = entity.IsPublished,
            };
        }

        public static ServiceEntity ServiceDataToEntity(ServiceDataModel data, ServiceEntity? entity = null)
        {
            entity ??= new ServiceEntity();

            entity.Id = data.Id;
            entity.Title = data.ServiceName;
            entity.ServiceDescription = data.ServiceDescription;
            entity.IsPublished = data.IsPublished;

            return entity;
        }
    }
}
