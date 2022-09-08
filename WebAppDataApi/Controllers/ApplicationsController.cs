using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;
using DataModels;

namespace WebAppDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/<ApplicationsController>
        [HttpGet]
        public async Task<ActionResult<ApplicationDataModel>> Get()
        {
            var applications = await _applicationService.GetAllApplicationsDataAsync();

            return Ok(applications);
        }

        // GET api/<ApplicationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDataModel>> Get(int id)
        {
            var application = await _applicationService.GetApplicationDataById(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        public async Task<ActionResult> Post(ApplicationDataModel data)
        {
            await _applicationService.AddApplicationToDbAsync(data);

            return Ok();
        }

        // PUT api/<ApplicationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ApplicationDataModel data)
        {
            var editedApplication = await _applicationService.GetApplicationDataById(data.Id);
            if (editedApplication == null)
            {
                return NotFound();
            }

            await _applicationService.EditApplicationToDb(data);

            return Ok();
        }

        // DELETE api/<ApplicationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedApplication = await _applicationService.GetApplicationDataById(id);
            if (deletedApplication == null)
            {
                return NotFound();
            }

            //А нужно ли их вообще удалять? Сдеалем вид что удалили.
            return Ok();
        }
    }
}
