using DataModels.Base;

namespace DataModels
{
    public class HeaderSloganDataModel : BaseDataModel
    {
        public string Slogan { get; set; } = default!;
        public bool IsUsed { get; set; }
    }
}
