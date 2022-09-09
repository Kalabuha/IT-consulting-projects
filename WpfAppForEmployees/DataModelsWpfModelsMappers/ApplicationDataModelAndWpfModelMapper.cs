using WpfAppForEmployees.WpfModels;
using DataModels;

namespace WpfAppForEmployees.DataModelsWpfModelsMappers
{
    public static class ApplicationDataModelAndWpfModelMapper
    {
        public static ApplicationWpfModel ApplicationDataModelToWpfModel(this ApplicationDataModel data)
        {
            return new ApplicationWpfModel
            {
                Id = data.Id,
                Number = data.Number,
                GuestName = data.GuestName ?? string.Empty,
                GuestEmail = data.GuestEmail ?? string.Empty,
                GuestApplicationText = data.GuestApplicationText ?? string.Empty,
                DateReceiptApplicationAsDateTime = data.DateReceiptApplication,
                Status = data.Status
            };
        }

        public static ApplicationDataModel ApplicationWpfModelToDataModel(this ApplicationWpfModel model)
        {
            return new ApplicationDataModel()
            {
                Id = model.Id,
                Number = model.Number,
                GuestName = model.GuestName,
                GuestEmail = model.GuestEmail,
                GuestApplicationText = model.GuestApplicationText,
                Status = model.Status,
            };
        }
    }
}
