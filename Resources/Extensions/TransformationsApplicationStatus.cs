using Resources.Enums;

namespace Resources.Extensions
{
    public static class TransformationsApplicationStatus
    {
        public static string TranslateApplicationStatusToDisplayPluralString(this ApplicationStatus status)
        {
            return status switch
            {
                ApplicationStatus.Indeterminate => "Неопределённые",
                ApplicationStatus.Initial => "Новые",
                ApplicationStatus.Being => "В работе",
                ApplicationStatus.Completed => "Завершенные",
                ApplicationStatus.Rejected => "Отклоненные",
                ApplicationStatus.Canceled => "Отмененные",
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
            };
        }

        public static string TranslateApplicationStatusToDisplaySingularString(this ApplicationStatus status)
        {
            return status switch
            {
                ApplicationStatus.Indeterminate => "Неопределена",
                ApplicationStatus.Initial => "Новая",
                ApplicationStatus.Being => "В работе",
                ApplicationStatus.Completed => "Завершена",
                ApplicationStatus.Rejected => "Отклонена",
                ApplicationStatus.Canceled => "Отменена",
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
            };
        }
    }
}
