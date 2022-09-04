using DataModels.Base;

namespace DataModels
{
    public class ServiceData : BaseData
    {
        public string ServiceName { get; set; } = default!;
        public string ServiceDescription { get; set; } = default!;
        public bool IsPublished { get; set; }
    }
}
