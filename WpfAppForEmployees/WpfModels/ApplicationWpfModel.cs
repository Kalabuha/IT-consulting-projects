using WpfAppForEmployees.WpfModels.Base;
using System;
using Enums;

namespace WpfAppForEmployees.WpfModels
{
    public class ApplicationWpfModel : BaseWpfModel
    {
        public int Number { get; set; }
        public string? GuestName { get; set; }
        public string? GuestEmail { get; set; }
        public string? GuestApplicationText { get; set; }

        public DateTime DateReceiptApplication { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
