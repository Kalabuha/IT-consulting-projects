using Enums;

namespace WebAppForAdmins.Models.Applications
{
    public class ApplicationsFilterViewModel
    {
        public ApplicationStatus[] RequestedStatuses { get; set; } = default!;
        public DateTimePeriod RequestedPeriod { get; set; }
        public DateTime? StartTimePeriod { get; set; }
        public DateTime? EndTimePeriod { get; set; }
    }
}
