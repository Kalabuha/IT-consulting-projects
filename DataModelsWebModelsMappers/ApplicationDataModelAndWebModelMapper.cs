using DataModels;
using WebModels;

namespace DataModelsWebModelsMappers
{
    public static class ApplicationDataModelAndWebModelMapper
    {
        public static ApplicationWebModel ApplicationDataToModel(this ApplicationDataModel data)
        {
            return new ApplicationWebModel
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

        public static ApplicationDataModel ApplicationModelToData(this ApplicationWebModel model)
        {
            return new ApplicationDataModel()
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
