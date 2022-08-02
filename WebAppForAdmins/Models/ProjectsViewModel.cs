using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class ProjectsViewModel
    {
        public IList<ProjectModel> Projects { get; set; } = default!;
    }
}
