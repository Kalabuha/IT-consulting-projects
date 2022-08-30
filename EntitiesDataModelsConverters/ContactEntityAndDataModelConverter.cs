using Entities;
using DataModels;

namespace EntitiesDataModelsConverters
{
    public static class ContactEntityAndDataModelConverter
    {
        public static ContactData ContactEntityToData(this ContactEntity entity)
        {
            return new ContactData
            {
                Id = entity.Id,
                Address = entity.Address,
                Postcode = entity.Postcode,
                Phone = entity.Phone,
                Fax = entity.Fax,
                MapAsString = Convert.ToBase64String(entity.MapAsArray64),
                IsPublished = entity.IsPublishedOnMainPage
            };
        }

        public static ContactEntity ContactDataToEntity(this ContactData data, ContactEntity? entity = null)
        {
            entity ??= new ContactEntity();

            if (!(string.IsNullOrEmpty(data.MapAsString) || string.IsNullOrWhiteSpace(data.MapAsString)))
            {
                entity.MapAsArray64 = Convert.FromBase64String(data.MapAsString);
            }

            entity.Id = data.Id;
            entity.Address = data.Address;
            entity.Postcode = data.Postcode;
            entity.Phone = data.Phone;
            entity.Fax = data.Fax;
            entity.IsPublishedOnMainPage = false;

            return entity;
        }
    }
}
