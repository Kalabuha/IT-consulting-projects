using Resources.Entities;
using Resources.Models;
using Resources.Datas;

namespace Services.Converters
{
    public static class ContactConverter
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

            entity.Id = data.Id;
            entity.Address = data.Address;
            entity.Postcode = data.Postcode;
            entity.Phone = data.Phone;
            entity.Fax = data.Fax;
            entity.MapAsArray64 = Convert.FromBase64String(data.MapAsString);
            entity.IsPublishedOnMainPage = false;

            return entity;
        }

        public static ContactModel ContactDataToModel(this ContactData data)
        {
            return new ContactModel
            {
                Id = data.Id,
                Address = data.Address,
                Postcode = data.Postcode,
                Phone = data.Phone,
                Fax = data.Fax,
                MapAsString = string.Format("data:image/jpg;base64,{0}", data.MapAsString),
                IsPublished = data.IsPublished,
            };
        }

        public static ContactData ContactModelToData(this ContactModel model)
        {
            return new ContactData
            {
                Id = model.Id,
                Address = model.Address,
                Postcode = model.Postcode,
                Phone = model.Phone,
                Fax = model.Fax,
                MapAsString = model.MapAsString,
                IsPublished = model.IsPublished,
            };
        }
    }
}
