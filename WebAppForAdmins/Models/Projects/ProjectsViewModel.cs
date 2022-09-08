using WebModels;

namespace WebAppForAdmins.Models.Projects
{
    public class ProjectsViewModel
    {
        public IList<ProjectWebModel> Projects { get; set; } = default!;
    }
}
