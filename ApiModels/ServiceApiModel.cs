using ApiModels.Base;

namespace ApiModels
{
    public class ServiceApiModel : BaseApiModel
    {
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public bool? IsPublished { get; set; }
    }
}
