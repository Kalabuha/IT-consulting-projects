using Entities;
using DataModels;

namespace EntitiesDataModelsMappers
{
    public static class ContactEntityAndDataModelMapper
    {
        public static ContactDataModel ContactEntityToData(this ContactEntity entity)
        {
            return new ContactDataModel
            {
                Id = entity.Id,
                Address = entity.Address,
                Postcode = entity.Postcode,
                Phone = entity.Phone,
                Fax = entity.Fax,
                MapAsByte = entity.MapAsArray64,
                IsPublished = entity.IsPublishedOnMainPage
            };
        }

        public static ContactEntity ContactDataToEntity(this ContactDataModel data, ContactEntity? entity = null)
        {
            entity ??= new ContactEntity();

            if (data.MapAsByte != null && data.MapAsByte.Length > 0)
            {
                entity.MapAsArray64 = data.MapAsByte;
            }

            entity.Id = data.Id;
            entity.Address = data.Address;
            entity.Postcode = data.Postcode;
            entity.Phone = data.Phone;
            entity.Fax = data.Fax;
            entity.IsPublishedOnMainPage = data.IsPublished;

            return entity;
        }
    }
}
