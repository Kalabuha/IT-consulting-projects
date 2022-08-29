namespace DataModels
{
    public class ContactData
    {
        public int Id { get; set; }

        public int Postcode { get; set; }

        public string Address { get; set; } = default!;

        public string Phone { get; set; } = default!;

        public string? Fax { get; set; }

        public string MapAsString { get; set; } = default!;

        public bool IsPublished { get; set; }
    }
}
