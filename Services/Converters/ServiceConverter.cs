using Resources.Entities;
using Resources.Models;
using Resources.Datas;

namespace Services.Converters
{
    public static class ServiceConverter
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
