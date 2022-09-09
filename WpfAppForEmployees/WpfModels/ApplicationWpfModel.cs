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

        public DateTime DateReceiptApplicationAsDateTime { get; set; } = default!;
        public string DateReceiptApplicationAsString
        {
            get => DateReceiptApplicationAsDateTime.ToString("dd.MM.yyyy");
        }

        public ApplicationStatus Status { get; set; }
    }
}
