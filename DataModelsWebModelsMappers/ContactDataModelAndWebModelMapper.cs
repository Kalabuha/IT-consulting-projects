using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsMappers
{
    public static class ContactDataModelAndWebModelMapper
    {
        public static ContactWebModel ContactDataToModel(this ContactDataModel data)
        {
            var imageAsString = Convert.ToBase64String(data.MapAsByte);

            return new ContactWebModel
            {
                Id = data.Id,
                Address = data.Address,
                Postcode = data.Postcode,
                Phone = data.Phone,
                Fax = data.Fax,
                MapAsString = string.Format("data:image/jpg;base64,{0}", imageAsString),
                IsPublished = data.IsPublished,
            };
        }

        public static ContactDataModel ContactModelToData(this ContactWebModel model)
        {
            if (model.MapAsFormFile != null)
            {
                model.MapAsString = ImageWebDataConverter.ConvertImageFromFormFileToBytes(model.MapAsFormFile);
            }

            var data = new ContactDataModel
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
                data.MapAsByte = Convert.FromBase64String(model.MapAsString);
            }

            return data;
        }
    }
}
