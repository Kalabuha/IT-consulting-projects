namespace DataModels
{
    public class ServiceData
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = default!;
        public string ServiceDescription { get; set; } = default!;
        public bool IsPublished { get; set; }
    }
}
