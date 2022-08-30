using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAppForAdmins.Models.Projects;
using WebServices.Interfaces;
using DataModelsWebModelsConverters;
using WebModels;

namespace WebAppForAdmins.Controllers
{
    [Authorize(Roles = "Senior, Admin")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _projectService.GetAllProjectDatasAsync();
            var models = datas.Select(d => d.ProjectDataToModel())
                .ToList();

            var viewModel = new ProjectsViewModel()
            {
                Projects = models
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.IsChangeDisabled = false;

            return View(new ProjectModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(ProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            var data = model.ProjectModelToData();
            await _projectService.AddProjectToDbAsync(data);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsChangeDisabled = false;

            var data = await _projectService.GetProjectDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.ProjectDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(ProjectModel model)
        {
            var oldData = await _projectService.GetProjectDataByIdAsync(model.Id);
            if (oldData == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var oldModel = oldData.ProjectDataToModel();
                model.CustomerCompanyLogoAsDataImage = oldModel.CustomerCompanyLogoAsDataImage;
                return View("Edit", model);
            }

            var data = model.ProjectModelToData();
            await _projectService.EditProjectToDbAsync(data);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.IsChangeDisabled = true;

            var data = await _projectService.GetProjectDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.ProjectDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _projectService.RemoveProjectToDbAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
