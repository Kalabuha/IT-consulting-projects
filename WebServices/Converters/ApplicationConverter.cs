using Entities;
using DataModels;
using WebModels;
using Enums;

namespace WebServices.Converters
{
    public static class ApplicationConverter
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
