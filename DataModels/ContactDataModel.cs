using DataModels.Base;

namespace DataModels
{
    public class ContactDataModel : BaseDataModel
    {
        public int Postcode { get; set; }
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? Fax { get; set; }
        public byte[] MapAsByte { get; set; } = default!;
        public bool IsPublished { get; set; }
    }
}
