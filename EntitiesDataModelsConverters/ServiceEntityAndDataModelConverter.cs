using DataModels;
using Entities;

namespace EntitiesDataModelsConverters
{
    public static class ServiceEntityAndDataModelConverter
    {
        public static ServiceData ServiceEntityToData(this ServiceEntity entity)
        {
            return new ServiceData
            {
                Id = entity.Id,
                ServiceName = entity.Title,
                ServiceDescription = entity.ServiceDescription,
                IsPublished = entity.IsPublished,
            };
        }

        public static ServiceEntity ServiceDataToEntity(this ServiceData data, ServiceEntity? entity = null)
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
