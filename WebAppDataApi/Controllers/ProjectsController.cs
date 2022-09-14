using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;
using DataModels;

namespace WebAppDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/<ProjectsController>
        [HttpGet]
        public async Task<ActionResult<List<ProjectDataModel>>> Get()
        {
            var projects = await _projectService.GetAllProjectDatasAsync();

            return Ok(projects);
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDataModel>> Get(int id)
        {
            var project = await _projectService.GetProjectDataByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<ActionResult> Post(ProjectDataModel project)
        {
            await _projectService.AddProjectToDbAsync(project, "..\\DefaultDataServices\\DefaultData\\img");

            return Ok();
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ProjectDataModel project)
        {
            var editedProject = _projectService.GetProjectDataByIdAsync(project.Id);
            if (editedProject == null)
            {
                return NotFound();
            }

            await _projectService.EditProjectToDbAsync(project);

            return Ok();
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedProject = _projectService.GetProjectDataByIdAsync(id);
            if (deletedProject == null)
            {
                return NotFound();
            }

            await _projectService.RemoveProjectToDbAsync(id);

            return Ok();
        }
    }
}
