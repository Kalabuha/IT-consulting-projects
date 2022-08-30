using Entities;
using DataModels;
using Enums;

namespace EntitiesDataModelsConverters
{
    public static class ApplicationEntityAndDataModelConverter
    {
        public static ApplicationData ApplicationEntityToData(this ApplicationEntity entity)
        {
            return new ApplicationData
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

        public static ApplicationEntity ApplicationDataToEntity(this ApplicationData data, ApplicationEntity? entity = null)
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
