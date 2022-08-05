using Resources.Models;

namespace WebAppForAdmins.Models.Projects
{
    public class ProjectsViewModel
    {
        public IList<ProjectModel> Projects { get; set; } = default!;
    }
}
