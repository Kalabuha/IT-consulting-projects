using WpfAppForEmployees.WpfModels.Base;

namespace WpfAppForEmployees.WpfModels
{
    public class ServiceWpfModel : BaseWpfModel
    {
        public string ServiceName { get; set; } = default!;
        public string ServiceDescription { get; set; } = default!;
        public bool IsPublished { get; set; }
    }
}
