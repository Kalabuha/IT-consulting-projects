using Microsoft.AspNetCore.Mvc;
using WebServices.Interfaces;
using DataModels;

namespace WebAppDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/<ServicesController>
        [HttpGet]
        public async Task<ActionResult<List<ServiceData>>> Get()
        {
            var services = await _serviceService.GetAllServiceDatasAsync();

            return Ok(services);
        }

        // GET api/<ServicesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceData>> Get(int id)
        {
            var service = await _serviceService.GetServiceDataByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // POST api/<ServicesController>
        [HttpPost]
        public async Task<ActionResult> Post(ServiceData service)
        {
            await _serviceService.AddServiceToDbAsync(service);

            return Ok();
        }

        // PUT api/<ServicesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ServiceData service)
        {
            var editedService = await _serviceService.GetServiceDataByIdAsync(service.Id);
            if (editedService == null)
            {
                return NotFound();
            }

            await _serviceService.EditServiceToDbAsync(service);

            return Ok();
        }

        // DELETE api/<ServicesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedService = await _serviceService.GetServiceDataByIdAsync(id);
            if (deletedService == null)
            {
                return NotFound();
            }

            await _serviceService.RemoveServiceToDbAsync(id);
            return Ok();
        }
    }
}
