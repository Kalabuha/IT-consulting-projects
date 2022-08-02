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

        public static ApplicationEntity ApplicationModelToEntity(this ApplicationModel model)
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

            return new ApplicationEntity
            {
                Id = model.Id,
                Number = model.Number,
                GuestName = model.GuestName ?? string.Empty,
                GuestEmail = model.GuestEmail ?? string.Empty,
                GuestsApplicationText = model.GuestApplicationText ?? string.Empty,
                DateReceipt = model.DateReceiptApplication,
                Status = status
            };
        }
    }
}
