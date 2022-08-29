namespace ConsoleAppCreateDbProfi.TestData.CreatorEntities
{
    internal class ProjectCreatorEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Link { get; set; } = default!;
        public string Image { get; set; } = default!;
        public bool IsUsed { get; set; }
    }
}
