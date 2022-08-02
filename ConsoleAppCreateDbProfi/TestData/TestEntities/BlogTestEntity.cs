namespace ConsoleAppCreateDbProfi.TestData.TestEntities
{
    internal class BlogTestEntity
    {
        public string Title { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public string LongDescription { get; set; } = default!;
        public string BlogImage { get; set; } = default!;
        public DateTime Publication { get; set; }
        public bool IsUsed { get; set; }
    }
}
