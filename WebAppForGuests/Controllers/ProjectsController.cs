using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebAppForGuests.Models;
using Services.Converters;

namespace WebAppForGuests.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectService _projectService;
        private readonly IHeaderService _headerService;

        public ProjectsController(ILogger<ProjectsController> logger, IProjectService projectService, IHeaderService headerService)
        {
            _logger = logger;
            _projectService = projectService;
            _headerService = headerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menuData = await _headerService.GetUsedMenuDataAsync();
            ViewBag.PageH1 = menuData.Projects;

            var datas = await _projectService.GetPublishedProjectDatasAsync();
            var models = datas.Select(p => p.ProjectDataToModel())
                .ToList();

            return View(new ProjectsViewModel { Projects = models });
        }

        [HttpGet]
        public async Task<IActionResult> ProjectDetails(int id)
        {
            var data = await _projectService.GetProjectDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.ProjectDataToModel();

            return View(new ProjectsViewModel { SelectedProject = model });
        }
    }
}
