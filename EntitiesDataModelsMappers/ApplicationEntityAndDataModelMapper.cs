using Entities;
using DataModels;
using Enums;

namespace EntitiesDataModelsMappers
{
    public static class ApplicationEntityAndDataModelMapper
    {
        public static ApplicationDataModel ApplicationEntityToData(ApplicationEntity entity)
        {
            return new ApplicationDataModel
            {
                Id = entity.Id,
                Number = entity.Number,
                GuestName = entity.GuestName,
                GuestEmail = entity.GuestEmail,
                GuestApplicationText = entity.GuestsApplicationText,
                DateReceiptApplication = entity.DateReceipt,
                Status = entity.Status
            };
        }

        public static ApplicationEntity ApplicationDataToEntity(ApplicationDataModel data, ApplicationEntity? entity = null)
        {
            entity ??= new ApplicationEntity();

            entity.Id = data.Id;
            entity.Number = data.Number;
            entity.GuestName = data.GuestName ?? string.Empty;
            entity.GuestEmail = data.GuestEmail ?? string.Empty;
            entity.GuestsApplicationText = data.GuestApplicationText ?? string.Empty;
            entity.DateReceipt = data.DateReceiptApplication;

            if (string.IsNullOrEmpty(data.GuestName) ||
                string.IsNullOrEmpty(data.GuestEmail) ||
                string.IsNullOrEmpty(data.GuestApplicationText))
            {
                entity.Status = ApplicationStatus.Indeterminate;
            }
            else
            {
                entity.Status = data.Status;
            }

            return entity;
        }
    }
}
