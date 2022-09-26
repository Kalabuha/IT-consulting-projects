using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;
using DataModelsApiModelsMappers;
using ApiModels;
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
        public async Task<ActionResult> Post(ProjectApiModel api)
        {
            if (!CheckIsValidProjectPostRequest(api))
            {
                return BadRequest();
            }

            var data = api.ProjectApiToData();
            await _projectService.AddProjectToDbAndAddDefaultImageAsync(data, "..\\DefaultDataServices\\DefaultData\\img");

            return Ok();
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ProjectApiModel api)
        {
            if (!CheckIsValidProjectPostRequest(api))
            {
                return BadRequest();
            }

            var data = api.ProjectApiToData();
            if (await _projectService.EditProjectToDbAsync(data))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _projectService.RemoveProjectToDbAsync(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        private bool CheckIsValidProjectPostRequest(ProjectApiModel api)
        {
            if (CheckStringIsNullOrEmptyOrWhiteSpace(api.ProjectTitle))
                return false;

            if (CheckStringIsNullOrEmptyOrWhiteSpace(api.ProjectDescription))
                return false;

            return true;
        }

        private bool CheckStringIsNullOrEmptyOrWhiteSpace(string? str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                return true;
            }

            return false;
        }
    }
}
