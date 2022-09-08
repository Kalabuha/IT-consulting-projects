using DataModels.Base;
using Enums;

namespace DataModels
{
    public class ApplicationDataModel : BaseDataModel
    {
        public int Number { get; set; }
        public string? GuestName { get; set; }
        public string? GuestEmail { get; set; }
        public string? GuestApplicationText { get; set; }

        public DateTime DateReceiptApplication { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
