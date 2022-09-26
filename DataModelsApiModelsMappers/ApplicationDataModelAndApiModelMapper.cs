using DataModels;
using ApiModels;
using Enums;

namespace DataModelsApiModelsMappers
{
    public static class ApplicationDataModelAndApiModelMapper
    {
        public static ApplicationApiModel ApplicationDataToApi(this ApplicationDataModel data)
        {
            return new ApplicationApiModel
            {
                Id = data.Id,
                Number = data.Number,
                GuestName = data.GuestName,
                GuestEmail = data.GuestEmail,
                GuestApplicationText = data.GuestApplicationText,
                DateReceiptApplication = data.DateReceiptApplication,
                Status = data.Status
            };
        }

        public static ApplicationDataModel ApplicationApiToData(this ApplicationApiModel api)
        {
            return new ApplicationDataModel()
            {
                Id = api.Id,
                Number = api.Number ?? 0,
                GuestName = api.GuestName ?? string.Empty,
                GuestEmail = api.GuestEmail ?? string.Empty,
                GuestApplicationText = api.GuestApplicationText ?? string.Empty,
                DateReceiptApplication = api.DateReceiptApplication ?? DateTime.Now,
                Status = api.Status ?? ApplicationStatus.Indeterminate,
            };
        }
    }
}
