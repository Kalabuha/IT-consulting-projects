using Enums;

namespace WebAppForAdmins.Models.Applications
{
    public class SelectApplicationStatusModel
    {
        public int SelectedApplicationId { get; set; }
        public ApplicationStatus SelectedStatus { get; set; }
    }
}
