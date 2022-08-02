namespace ConsoleAppCreateDbProfi.TestData.TestEntities
{
    internal class ProjectTestEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Link { get; set; } = default!;
        public string Image { get; set; } = default!;
        public bool IsUsed { get; set; }
    }
}
