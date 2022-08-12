using Resources.Entities;
using Resources.Models;
using Resources.Enums;

namespace Services.Converters
{
    public static class ApplicationConverter
    {
        public static ApplicationModel ApplicationEntityToModel(this ApplicationEntity entity)
        {
            return new ApplicationModel
            {
                Id = entity.Id,
                Number = entity.Number,
                GuestName = entity.GuestName,
                GuestEmail = entity.GuestEmail,
                GuestApplicationText = entity.GuestsApplicationText ?? "Текст сообщения отсутствует",
                DateReceiptApplication = entity.DateReceipt,
                Status = entity.Status
            };
        }

        public static ApplicationEntity ApplicationModelToEntity(this ApplicationModel model, ApplicationEntity? entity = null)
        {
            ApplicationStatus status;
            if (model.GuestName == null || model.GuestEmail == null || model.GuestApplicationText == null)
            {
                status = ApplicationStatus.Indeterminate;
            }
            else
            {
                status = model.Status;
            }

            entity ??= new ApplicationEntity();

            entity.Id = model.Id;
            entity.Number = model.Number;
            entity.GuestName = model.GuestName ?? string.Empty;
            entity.GuestEmail = model.GuestEmail ?? string.Empty;
            entity.GuestsApplicationText = model.GuestApplicationText ?? string.Empty;
            entity.DateReceipt = model.DateReceiptApplication;
            entity.Status = status;

            return entity;
        }
    }
}
