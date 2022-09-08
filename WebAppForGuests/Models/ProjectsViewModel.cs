using WebModels;

namespace WebAppForGuests.Models
{
    public class ProjectsViewModel
    {
        public ProjectWebModel? SelectedProject { get; set; }
        public List<ProjectWebModel>? Projects { get; set; }
    }
}
