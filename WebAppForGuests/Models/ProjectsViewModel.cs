using WebModels;

namespace WebAppForGuests.Models
{
    public class ProjectsViewModel
    {
        public ProjectModel? SelectedProject { get; set; }
        public List<ProjectModel>? Projects { get; set; }
    }
}
