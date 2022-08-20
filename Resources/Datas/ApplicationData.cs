using Resources.Datas.Base;
using Resources.Enums;

namespace Resources.Datas
{
    public class ApplicationData : BaseData
    {
        public int Number { get; set; }
        public string? GuestName { get; set; }
        public string? GuestEmail { get; set; }
        public string? GuestApplicationText { get; set; }

        public DateTime DateReceiptApplication { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
