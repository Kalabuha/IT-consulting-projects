namespace ConsoleAppCreateDbProfi.TestData.TestEntities
{
    internal class ContactTestEntity
    {
        public int Postcode { get; set; }
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? Fax { get; set; }
        public string Map { get; set; } = default!;
        public bool IsPosted { get; set; }
    }
}
