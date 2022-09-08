using DataModels.Base;

namespace DataModels
{
    public class MainPageImageDataModel : BaseDataModel
    {
        public byte[] ImageAsByte { get; set; } = default!;
    }
}
