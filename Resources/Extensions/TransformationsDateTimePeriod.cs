using Resources.Enums;

namespace Resources.Extensions
{
    public static class TransformationsDateTimePeriod
    {
        public static string TranslateDateTimePeriodToDisplayString(this DateTimePeriod period)
        {
            return period switch
            {
                DateTimePeriod.HalfDay => "За день",
                DateTimePeriod.Day => "За сутки",
                DateTimePeriod.Week => "За неделю",
                DateTimePeriod.Month => "За месяц",
                DateTimePeriod.AllTime => "За всё время",
                DateTimePeriod.SelectedPeriodDateTime => "Свой",
                _ => throw new ArgumentOutOfRangeException(nameof(period), period, null)
            };
        }

        public static DateTime GetStartDateTimePeriod(this DateTimePeriod period)
        {
            return period switch
            {
                DateTimePeriod.HalfDay => DateTime.Now.AddHours(-12),
                DateTimePeriod.Day => DateTime.Now.AddDays(-1),
                DateTimePeriod.Week => DateTime.Now.AddDays(-7),
                DateTimePeriod.Month => DateTime.Now.AddMonths(-1),
                DateTimePeriod.AllTime => new DateTime(),
                DateTimePeriod.SelectedPeriodDateTime => DateTime.Now,
                _ => throw new ArgumentOutOfRangeException(nameof(period), period, null)
            };
        }
    }
}
