using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsConverters
{
    public static class ContactDataModelAndWebModelConverter
    {
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
            if (model.MapAsFormFile != null)
            {
                model.MapAsString = ImageWebDataConverter.ReadBytesFromFormFile(model.MapAsFormFile);
            }

            var data = new ContactData
            {
                Id = model.Id,
                Address = model.Address,
                Postcode = model.Postcode,
                Phone = model.Phone,
                Fax = model.Fax,
                IsPublished = model.IsPublished,
            };

            if (!string.IsNullOrEmpty(model.MapAsString))
            {
                data.MapAsString = model.MapAsString;
            }

            return data;
        }
    }
}
