using Resources.Models.Base;
using Resources.Enums;

namespace Resources.Models
{
    public class ApplicationModel : BaseModel
    {
        public int Number { get; set; }
        public string? GuestName { get; set; } = default!;
        public string? GuestEmail { get; set; } = default!;
        public string? GuestApplicationText { get; set; } = default!;
        public DateTime DateReceiptApplication { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
