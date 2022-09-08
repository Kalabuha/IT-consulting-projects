using DataModels.Base;

namespace DataModels
{
    public class ServiceDataModel : BaseDataModel
    {
        public string ServiceName { get; set; } = default!;
        public string ServiceDescription { get; set; } = default!;
        public bool IsPublished { get; set; }
    }
}
