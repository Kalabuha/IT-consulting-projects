using DataModels;
using WebModels;

namespace DataModelsWebModelsConverters
{
    public static class ApplicationDataModelAndWebModelConverter
    {
        public static ApplicationModel ApplicationDataToModel(this ApplicationData data)
        {
            return new ApplicationModel
            {
                Id = data.Id,
                Number = data.Number,
                GuestName = data.GuestName ?? string.Empty,
                GuestEmail = data.GuestEmail ?? string.Empty,
                GuestApplicationText = data.GuestApplicationText ?? string.Empty,
                DateReceiptApplication = data.DateReceiptApplication,
                Status = data.Status
            };
        }

        public static ApplicationData ApplicationModelToData(this ApplicationModel model)
        {
            return new ApplicationData()
            {
                Id = model.Id,
                Number = model.Number,
                GuestName = model.GuestName,
                GuestEmail = model.GuestEmail,
                GuestApplicationText = model.GuestApplicationText,
                DateReceiptApplication = model.DateReceiptApplication,
                Status = model.Status,
            };
        }
    }
}
